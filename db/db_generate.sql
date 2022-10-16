DROP database IF EXISTS todo;

CREATE DATABASE todo
    WITH 
    ENCODING = 'UTF8';

USE todo;

CREATE TABLE users
(
    id serial NOT NULL,
    email character varying(126) NOT NULL,
    password character varying(8) NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT uemail UNIQUE (email)
);

CREATE TABLE categories
(
    id serial NOT NULL,
    name character varying(56) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tasks
(
    id serial NOT NULL,
    name character varying(126) NOT NULL,
    is_done boolean NOT NULL,
    priority int NOT NULL,
    category_id integer,
    PRIMARY KEY (id),
    CONSTRAINT fc_category FOREIGN KEY (category_id)
        REFERENCES public.categories (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
);
