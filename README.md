# Quiz Management System

A complete **Windows Forms** application built in **C# (.NET Framework 4.7.2)** featuring a custom **Doubly Linked List** for question management and **SQL Server** (ADO.NET) for persistence.

---

## Project Structure

```
QuizManagementSystem/
├── QuizManagementDB.sql               ← Run this in SSMS first
├── QuizManagementSystem.sln           ← Open this in Visual Studio
├── README.md
└── QuizManagementSystem/
    ├── Helpers/       AppSession.cs
    ├── Models/        Student, Question, Exam, Result, StudentAnswer
    ├── DataStructures/QuestionNode.cs, QuestionLinkedList.cs
    ├── Database/      DatabaseConnection, StudentRepository,
    │                  QuestionRepository, ExamRepository, ResultRepository
    └── Forms/         LoginForm, AdminDashboard, StudentDashboard,
                       ManageQuestionsForm, TakeQuizForm, ViewResultsForm
```

---

## Setup Instructions

### Step 1 — Create the Database

1. Open **SQL Server Management Studio (SSMS 22)**
2. Connect to `localhost`
3. Open `QuizManagementDB.sql` (located in the root folder)
4. Press **F5** to execute → database and seed data will be created

### Step 2 — Open the Solution

1. Open **Visual Studio 2022**
2. File → Open → `QuizManagementSystem.sln`
3. Build → Build Solution (`Ctrl+Shift+B`)
4. Run with `F5`

### Step 3 — Login

| Role    | Email                 |
|---------|-----------------------|
| Admin   | `admin@quiz.com`      |
| Student | `alice@student.com`   |
| Student | `bob@student.com`     |

The demo accounts are created by `QuizManagementDB.sql`. Their passwords are in the seed section of that file - change them after your first login.

---

## Features

### Admin

- **Students** — Add / Edit / Delete students
- **Questions** — Manage with the Doubly LinkedList editor (Prev / Next navigation)
- **Exams** — Add / Edit / Delete exams
- **Results** — View all student results with detailed per-question breakdown

### Student
- **Take Quiz** — Select an exam, answer questions using **Prev / Next** navigation (backed by the custom doubly linked list), submit for instant grading
- **Countdown Timer** — Auto-submits when time expires
- **My Results** — View all past attempts with detailed answer breakdown

---

## Key Technical Details

### Custom Doubly Linked List
- `QuestionNode`: holds question data + `Next` / `Previous` pointers
- `QuestionLinkedList`: `AddQuestion`, `DeleteQuestion`, `GetNext`, `GetPrevious`, `UpdateQuestion`, `GetAllQuestions`, `LoadFromList`
- Used in both **ManageQuestionsForm** (CRUD) and **TakeQuizForm** (navigation)

### Database Layer (ADO.NET)
- `DatabaseConnection` — parameterised `ExecuteNonQuery`, `ExecuteQuery`, `ExecuteScalar`
- All queries use `SqlParameter` (SQL injection prevention)
- `using` statements on all connections

### Connection String
```
Data Source=localhost;Initial Catalog=QuizManagementDB;Integrated Security=True
```
Modify in `Database/DatabaseConnection.cs` if your SQL Server instance name differs.

---

## Database Schema

| Table          | Key Columns                                                     |
|----------------|-----------------------------------------------------------------|
| Students       | student_id (PK), name, email, password, registration_number, is_admin |
| Questions      | question_id (PK), question_text, option_a–d, correct_answer, subject, marks |
| Exams          | exam_id (PK), exam_name, subject, total_marks, duration_minutes |
| Results        | result_id (PK), student_id (FK), exam_id (FK), obtained_marks, percentage |
| StudentAnswers | answer_id (PK), result_id (FK), question_id (FK), student_answer, is_correct |

---

## Requirements

- **Visual Studio 2022** (or later)
- **.NET Framework 4.7.2**
- **SQL Server** (any edition) with Windows Authentication on `localhost`
- **SSMS 22** to run the SQL script
