PGDMP         ,                z           DB_Final    14.2    14.2 
    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    24586    DB_Final    DATABASE     n   CREATE DATABASE "DB_Final" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE "DB_Final";
                postgres    false            �            1259    24587    clientlogin    TABLE     z   CREATE TABLE public.clientlogin (
    username character varying(20) NOT NULL,
    pass character varying(15) NOT NULL
);
    DROP TABLE public.clientlogin;
       public         heap    postgres    false            �            1259    24592    employeelogin    TABLE     |   CREATE TABLE public.employeelogin (
    username character varying(20) NOT NULL,
    pass character varying(15) NOT NULL
);
 !   DROP TABLE public.employeelogin;
       public         heap    postgres    false            �          0    24587    clientlogin 
   TABLE DATA           5   COPY public.clientlogin (username, pass) FROM stdin;
    public          postgres    false    209   �	       �          0    24592    employeelogin 
   TABLE DATA           7   COPY public.employeelogin (username, pass) FROM stdin;
    public          postgres    false    210   �	       `           2606    24591    clientlogin clientlogin_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.clientlogin
    ADD CONSTRAINT clientlogin_pkey PRIMARY KEY (username);
 F   ALTER TABLE ONLY public.clientlogin DROP CONSTRAINT clientlogin_pkey;
       public            postgres    false    209            b           2606    24596     employeelogin employeelogin_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.employeelogin
    ADD CONSTRAINT employeelogin_pkey PRIMARY KEY (username);
 J   ALTER TABLE ONLY public.employeelogin DROP CONSTRAINT employeelogin_pkey;
       public            postgres    false    210            �      x�K��L�+�44261����� 2�:      �      x�+-N-�K�M�,H,..�/J����� i��     