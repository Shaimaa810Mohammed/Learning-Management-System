# Learning Management System (LMS)

A web-based **Learning Management System (LMS)** that helps manage online learning by providing features for **course creation**, **student enrollment**, and **assessments** such as quizzes and assignments.  
The system supports three main roles: **Admin**, **Instructor**, and **Student**, each with different permissions.

---

## 📌 Project Overview

This LMS allows instructors to create and manage courses, upload learning materials, create quizzes and assignments, and grade student submissions.  
Students can enroll in courses, access lessons and materials, take quizzes, submit assignments, and track their grades.  
Admins manage users, system settings, and overall course management.

---

## 👥 User Roles & Permissions

### 🔹 Admin
- Manage system settings.
- Create and manage user accounts.
- Create and manage courses.
- View enrolled students in each course.

### 🔹 Instructor
- Create and manage courses (title, description, duration, etc.).
- Upload course materials (PDFs, videos, audio files, etc.).
- Create and manage course lessons.
- Create quizzes and assignments.
- Create question banks per course.
- Grade quizzes and assignment submissions.
- View enrolled students in each course.
- Remove students from courses.

### 🔹 Student
- Register and login to the system.
- View available courses and enroll.
- Access course lessons and uploaded materials.
- Take quizzes.
- Submit assignments by uploading files.
- View quiz and assignment grades.

---

## 🚀 Main Features

### ✅ 1. User Management
- Role-based user system (**Admin / Instructor / Student**)
- User registration and login
- Role-based access control
- Profile management (view / update personal data)

---

### ✅ 2. Course Management

#### Course Creation
- Instructors can create courses with details such as:
  - Title
  - Description
  - Duration
  - Course lessons
- Upload course media:
  - Videos
  - PDFs
  - Audio files

#### Enrollment Management
- Students can browse and enroll in available courses.
- Admins and instructors can view enrolled students for each course.

---

### ✅ 3. Assessment & Grading

#### Quiz Management
- Instructors can create quizzes with multiple question types:
  - MCQ (Multiple Choice Questions)
  - True / False
  - Short Answer
- Question bank per course

#### Assignment Management
- Instructors can create assignments for courses.
- Students can submit assignments by uploading files.
- Instructors can review and grade submissions.

---

## 🛠️ Technologies Used
- ASP.NET Core (MVC)
- Entity Framework Core (EF Core)
- LINQ
- SQL Server
- HTML, CSS, JavaScript
- Bootstrap
- Identity (Role-based authentication)
