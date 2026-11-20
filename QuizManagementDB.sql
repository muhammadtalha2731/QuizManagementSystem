-- ============================================================
-- Quiz Management System - Database Creation Script
-- Run this in SSMS 22 before launching the application
-- ============================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QuizManagementDB')
    DROP DATABASE QuizManagementDB;
GO

CREATE DATABASE QuizManagementDB;
GO

USE QuizManagementDB;
GO

-- ============================================================
-- TABLE: Students
-- ============================================================
CREATE TABLE Students (
    student_id          INT IDENTITY(1,1) PRIMARY KEY,
    name                NVARCHAR(100)  NOT NULL,
    email               NVARCHAR(150)  NOT NULL UNIQUE,
    password            NVARCHAR(100)  NOT NULL,
    registration_number NVARCHAR(50)   NOT NULL UNIQUE,
    is_admin            BIT            NOT NULL DEFAULT 0
);
GO

-- ============================================================
-- TABLE: Questions
-- ============================================================
CREATE TABLE Questions (
    question_id   INT IDENTITY(1,1) PRIMARY KEY,
    question_text NVARCHAR(500) NOT NULL,
    option_a      NVARCHAR(200) NOT NULL,
    option_b      NVARCHAR(200) NOT NULL,
    option_c      NVARCHAR(200) NOT NULL,
    option_d      NVARCHAR(200) NOT NULL,
    correct_answer CHAR(1)      NOT NULL CHECK (correct_answer IN ('A','B','C','D')),
    subject       NVARCHAR(100) NOT NULL,
    marks         INT           NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- TABLE: Exams
-- ============================================================
CREATE TABLE Exams (
    exam_id          INT IDENTITY(1,1) PRIMARY KEY,
    exam_name        NVARCHAR(200) NOT NULL,
    subject          NVARCHAR(100) NOT NULL,
    total_marks      INT           NOT NULL,
    duration_minutes INT           NOT NULL DEFAULT 30
);
GO

-- ============================================================
-- TABLE: Results
-- ============================================================
CREATE TABLE Results (
    result_id      INT IDENTITY(1,1) PRIMARY KEY,
    student_id     INT            NOT NULL FOREIGN KEY REFERENCES Students(student_id) ON DELETE CASCADE,
    exam_id        INT            NOT NULL FOREIGN KEY REFERENCES Exams(exam_id),
    obtained_marks INT            NOT NULL DEFAULT 0,
    total_marks    INT            NOT NULL,
    percentage     DECIMAL(5,2)   NOT NULL DEFAULT 0,
    attempt_date   DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
-- TABLE: StudentAnswers
-- ============================================================
CREATE TABLE StudentAnswers (
    answer_id      INT IDENTITY(1,1) PRIMARY KEY,
    result_id      INT   NOT NULL FOREIGN KEY REFERENCES Results(result_id) ON DELETE CASCADE,
    question_id    INT   NOT NULL FOREIGN KEY REFERENCES Questions(question_id),
    student_answer CHAR(1) NOT NULL,
    is_correct     BIT   NOT NULL DEFAULT 0
);
GO

-- ============================================================
-- SEED DATA
-- ============================================================

-- Default Admin (is_admin = 1)
INSERT INTO Students (name, email, password, registration_number, is_admin)
VALUES ('Administrator', 'admin@quiz.com', 'Admin@123', 'ADMIN-001', 1);

-- Sample Students
INSERT INTO Students (name, email, password, registration_number, is_admin)
VALUES ('Alice Johnson', 'alice@student.com', 'Alice@123', 'STU-2024-001', 0);

INSERT INTO Students (name, email, password, registration_number, is_admin)
VALUES ('Bob Smith', 'bob@student.com', 'Bob@123', 'STU-2024-002', 0);

-- Sample Questions (Computer Science)
INSERT INTO Questions (question_text, option_a, option_b, option_c, option_d, correct_answer, subject, marks)
VALUES 
('What does CPU stand for?', 'Central Processing Unit', 'Core Processing Unit', 'Computer Personal Unit', 'Central Program Utility', 'A', 'Computer Science', 2),
('Which data structure uses LIFO principle?', 'Queue', 'Stack', 'Array', 'Tree', 'B', 'Computer Science', 2),
('What is the time complexity of Binary Search?', 'O(n)', 'O(n^2)', 'O(log n)', 'O(1)', 'C', 'Computer Science', 2),
('Which language is used for web styling?', 'Java', 'Python', 'HTML', 'CSS', 'D', 'Computer Science', 2),
('What is a primary key in a database?', 'A key that locks the database', 'A unique identifier for each record', 'The first column of a table', 'An index for fast search', 'B', 'Computer Science', 2);

-- Sample Questions (Mathematics)
INSERT INTO Questions (question_text, option_a, option_b, option_c, option_d, correct_answer, subject, marks)
VALUES
('What is the value of Pi (approx)?', '2.14', '3.14', '4.14', '1.14', 'B', 'Mathematics', 1),
('What is 12 x 12?', '124', '132', '144', '156', 'C', 'Mathematics', 1),
('Solve: 2x + 5 = 11. What is x?', '2', '3', '4', '5', 'B', 'Mathematics', 1);

-- Sample Exams
INSERT INTO Exams (exam_name, subject, total_marks, duration_minutes)
VALUES ('Computer Science Basics', 'Computer Science', 10, 20);

INSERT INTO Exams (exam_name, subject, total_marks, duration_minutes)
VALUES ('Mathematics Fundamentals', 'Mathematics', 3, 15);
GO

PRINT 'QuizManagementDB created and seeded successfully!';
GO
