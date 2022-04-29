--Create Sequences 
CREATE SEQUENCE emp_serial;

CREATE SEQUENCE cust_serial;

CREATE SEQUENCE order_serial;

CREATE SEQUENCE proj_serial;


--Create Tables
CREATE TABLE IF NOT EXISTS Address
    (
        --AID INTEGER PRIMARY KEY,
        Street VARCHAR(50) PRIMARY KEY,
        City VARCHAR(30) NOT NULL,
        State VARCHAR(2) NOT NULL,
        Zip NUMERIC(5,0) NOT NULL
    );

CREATE TABLE IF NOT EXISTS Employee
    (
        EID INTEGER PRIMARY KEY DEFAULT nextval('emp_serial'), 
        Fname VARCHAR(50) NOT NULL, 
        Lname VARCHAR(50) NOT NULL, 
        Email VARCHAR(50) NOT NULL, 
        Phone CHAR(12) NOT NULL,
        Salary INTEGER,
        Available BOOLEAN NOT NULL,
        Address VARCHAR(50) REFERENCES Address ON DELETE SET NULL,
        CHECK (Salary > 0),
        CONSTRAINT emp_unique UNIQUE (Email, Phone)
    );

CREATE TABLE IF NOT EXISTS Machinery_Operator
    (
        EID INTEGER REFERENCES Employee ON DELETE CASCADE, 
        Certification VARCHAR(50), 
        CONSTRAINT operator_pk PRIMARY KEY (EID,Certification)
    );

CREATE TABLE IF NOT EXISTS Staff
    (
        EID INTEGER PRIMARY KEY REFERENCES Employee ON DELETE CASCADE,
        Job_Title VARCHAR(50) NOT NULL
    );

CREATE TABLE IF NOT EXISTS Customer
    (
        CID INTEGER PRIMARY KEY DEFAULT nextval('cust_serial'),
        Fname VARCHAR(50) NOT NULL,
        Lname VARCHAR(50) NOT NULL,
        Phone CHAR(12) NOT NULL,
        Email VARCHAR(50) NOT NULL,
        Address VARCHAR(50) REFERENCES Address ON DELETE SET NULL,
        CONSTRAINT cust_unique UNIQUE (Phone, Email, Address)
    );

CREATE TABLE IF NOT EXISTS Supplier
    (
        Name VARCHAR(100) PRIMARY KEY,
        Phone CHAR(12) NOT NULL,
        Email VARCHAR(50) NOT NULL,
        Address VARCHAR(50) REFERENCES Address ON DELETE SET NULL,
        CONSTRAINT supp_unique UNIQUE (Phone, Email, Address)
    );

CREATE TABLE IF NOT EXISTS Inventory
    (
        Name VARCHAR(20) PRIMARY KEY,
        Quantity INTEGER,
        Units VARCHAR(50) NOT NULL,
        CHECK (Quantity > 0)
    );

CREATE TABLE IF NOT EXISTS Purchase
    (
        OrderID INTEGER PRIMARY KEY DEFAULT nextval('order_serial'),
        EID INTEGER REFERENCES Employee ON DELETE SET NULL,
        Supplier VARCHAR(100) REFERENCES Supplier ON DELETE CASCADE,
        Quantity INTEGER,
        Material VARCHAR(20) REFERENCES Inventory ON DELETE CASCADE,
        Price NUMERIC(7,2),
        CHECK (Quantity > 0 AND Price > 0)
    );

CREATE TABLE IF NOT EXISTS Project
    (
        PID INTEGER PRIMARY KEY DEFAULT nextval('proj_serial'),
        Start DATE NOT NULL,
        Deadline DATE NOT NULL,
        Location VARCHAR(50) REFERENCES Address NOT NULL,
        Payment NUMERIC(9,2),
        Budget NUMERIC(9,2),
        NOTES TEXT,
        Proposed INTEGER REFERENCES Customer NOT NULL,
        CHECK (Start <= Deadline AND Payment > 0 AND Budget <= Payment) 
    );

CREATE TABLE IF NOT EXISTS Working
    (
        PID INTEGER REFERENCES Project ON DELETE CASCADE,
        EID INTEGER REFERENCES Employee ON DELETE SET NULL,
        CONSTRAINT working_pk PRIMARY KEY (PID,EID)
    );

CREATE TABLE IF NOT EXISTS EmpLogin
    (
        Users VARCHAR(50) PRIMARY KEY,
        EID INTEGER REFERENCES Employee ON DELETE CASCADE,
        Pass VARCHAR(20) NOT NULL
    );

CREATE TABLE IF NOT EXISTS CustLogin
    (
        Users VARCHAR(50) PRIMARY KEY,
        CID INTEGER REFERENCES Customer ON DELETE CASCADE,
        Pass VARCHAR(20) NOT NULL
    );


--Bulk copy initial table data
\copy Address FROM 'Data - CSV/Address.csv' WITH DELIMITER ',' CSV HEADER;

\copy Employee FROM 'Data - CSV/Employee.csv' WITH DELIMITER ',' CSV HEADER;

\copy Machinery_Operator FROM 'Data - CSV/Machinery Operator.csv' WITH DELIMITER ',' CSV HEADER;

\copy Staff FROM 'Data - CSV/Staff.csv' WITH DELIMITER ',' CSV HEADER;

\copy Customer FROM 'Data - CSV/Customer.csv' WITH DELIMITER ',' CSV HEADER;

\copy Supplier FROM 'Data - CSV/Supplier.csv' WITH DELIMITER ',' CSV HEADER;

\copy Inventory FROM 'Data - CSV/Inventory.csv' WITH DELIMITER ',' CSV HEADER;

\copy Purchase FROM 'Data - CSV/Purchase.csv' WITH DELIMITER ',' CSV HEADER;

\copy Project FROM 'Data - CSV/Project.csv' WITH DELIMITER ',' CSV HEADER;

\copy Working FROM 'Data - CSV/Working.csv' WITH DELIMITER ',' CSV HEADER;

\copy EmpLogin FROM 'Data - CSV/EmpLogin.csv' WITH DELIMITER ',' CSV HEADER;

\copy CustLogin FROM 'Data - CSV/CustLogin.csv' WITH DELIMITER ',' CSV HEADER;


--Sequence Updates
SELECT setval('emp_serial', max(EID)) FROM Employee;

SELECT setval('cust_serial', max(CID)) FROM Customer;

SELECT setval('order_serial', max(OrderID)) FROM Purchase;

SELECT setval('proj_serial', max(PID)) FROM Project;


-- Creating functions
create or replace function e_login(_username character varying, _password character varying)
returns int as
$$
begin
	if(select count(*) from emplogin where users = _username and pass = _password) > 0 then
		return 1;
	else
		return 0;
	end if;
end
$$
language plpgsql;


create or replace function u_login(_username character varying, _password character varying)
returns int as
$$
begin
	if(select count(*) from custlogin where users = _username and pass = _password) > 0 then
		return 1;
	else
		return 0;
	end if;
end
$$
language plpgsql;

CREATE OR REPLACE FUNCTION make_account()
RETURNS TRIGGER AS
$$
begin
    INSERT INTO EmpLogin VALUES(NEW.EID, NEW.EID, 'default');
    RETURN NULL;
end
$$
language plpgsql;


-- CREATE TRIGGERS
CREATE OR REPLACE TRIGGER new_manager AFTER INSERT ON Staff EXECUTE PROCEDURE make_account();


