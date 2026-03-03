# 🏨 Phumla Kamnandi Hotels: Guest Booking Subsystem
### *Systems Design & Development | INF2011S Specification*

---

## 📌 Project Overview
The **Phumla Kamnandi Guest Booking Subsystem** is a centralized hotel management solution designed for a growing empowerment group in South Africa. It standardizes the reservation process, guest management, and financial reporting across multiple hotel locations.

This repository contains the **System Specification** and the **C# implementation** for the first iteration of the project.

---

## 🎯 Key Objectives
* **Booking Lifecycle:** Full support for Making, Changing, and Cancelling bookings.
* **Financial Logic:** Automatic 10% deposit calculation and seasonal pricing.
* **Data Integrity:** Real-time room availability checks and guest verification.
* **Business Intelligence:** * **Occupancy Level Reports:** Identifying trends to maintain >50% profitability.
    * **Revenue Analysis:** Tracking financial performance against targets.

---

## 🏗 System Architecture
The project utilizes a **3-Tier Architecture** to ensure clean separation of concerns:

1. **Presentation Layer:** WinForms (C# .NET) providing the User Interface.
2. **Business Logic Layer:** Controllers (Booking, Guest, Room, Payment) managing business rules.
3. **Data Access Layer (DAL):** Dedicated DA classes for SQL interactions and data persistence.



### 📊 Database Design (ERD)
The system is backed by a relational database normalized to **3rd Normal Form (3NF)**.
* **Entities:** Guest, Booking, Room, Payment, Rate.
* **Constraint:** 1:M relationships to ensure data integrity and prevent overbooking.



---

## 🛠 Installation
1. **Clone the repo:** `git clone https://github.com/YourUsername/PhumlaKamnandi.git`
2. **Open in IDE:** Use **VS Code**.
3. **Database:** Ensure your connection string in the DA classes points to your local SQL instance.
4. **Build:** Run `dotnet build` or press `F5` in your IDE.

---

## 👥 Team Members
* **Abdallah Elahee** (ELHABD002)
* **Jack Saunders** (SNDAC007)
* **Mateo Montoya-Pelaez** (MNTMAT024)
* **Rory Cupido** (CPDROR001)