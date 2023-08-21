
--drop db
DROP  Assign7

---create db
CREATE DATABASE Assign7

--use db
USE Assign7

--create table
CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(100),
    Author NVARCHAR(50),
    Genre NVARCHAR(50),
    Quantity INT
);


INSERT INTO Books(BookID, Title, Author, Genre, Quantity)
VALUES
    (1, 'The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 5),
    (2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 10),
    (3, '1984', 'George Orwell', 'Science Fiction', 3),
    (4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 7);

	SELECT * FROM Books
