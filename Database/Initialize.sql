CREATE TABLE IF NOT EXISTS Address
    (
        AID INTEGER PRIMARY KEY,
        Street VARCHAR(50),
        City VARCHAR(30),
        State VARCHAR(2),
        Zip NUMERIC(5,0)
    );

CREATE TABLE IF NOT EXISTS Employee
    (
        EID INTEGER PRIMARY KEY, 
        Fname VARCHAR(50), 
        Lname VARCHAR(50), 
        Email VARCHAR(50), 
        Phone CHAR(12),
        Salary INTEGER,
        Available BOOLEAN,
        Address INTEGER REFERENCES Address
    );

CREATE TABLE IF NOT EXISTS Machinery_Operator
    (
        EID INTEGER REFERENCES Employee,
        Certification VARCHAR(50), 
        CONSTRAINT operator_pk PRIMARY KEY (EID,Certification)
    );

CREATE TABLE IF NOT EXISTS Staff
    (
        EID INTEGER PRIMARY KEY REFERENCES Employee,
        Job_Title VARCHAR(50)
    );

CREATE TABLE IF NOT EXISTS Customer
    (
        CID INTEGER PRIMARY KEY,
        Fname VARCHAR(50),
        Lname VARCHAR(50),
        Phone CHAR(12),
        Email VARCHAR(50),
        Address INTEGER REFERENCES Address
    );

CREATE TABLE IF NOT EXISTS Supplier
    (
        Name VARCHAR(100) PRIMARY KEY,
        Phone CHAR(12),
        Email VARCHAR(50),
        Address INTEGER REFERENCES Address
    );

CREATE TABLE IF NOT EXISTS Inventory
    (
        Name VARCHAR(20) PRIMARY KEY,
        Quantity INTEGER,
        Units VARCHAR(50)
    );

CREATE TABLE IF NOT EXISTS Purchase
    (
        OrderID INTEGER PRIMARY KEY,
        EID INTEGER REFERENCES Employee,
        Supplier VARCHAR(100) REFERENCES Supplier,
        Quantity INTEGER,
        Material VARCHAR(20) REFERENCES Inventory,
        Price NUMERIC(7,2)  
    );

CREATE TABLE IF NOT EXISTS Project
    (
        PID INTEGER PRIMARY KEY,
        Start DATE,
        Deadline DATE,
        Location INTEGER REFERENCES Address,
        Payment NUMERIC(9,2),
        Budget NUMERIC(9,2),
        NOTES TEXT,
        Proposed INTEGER REFERENCES Customer 
    );

CREATE TABLE IF NOT EXISTS Working
    (
        PID INTEGER REFERENCES Project,
        EID INTEGER REFERENCES Employee,
        CONSTRAINT working_pk PRIMARY KEY (PID,EID)
    );

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