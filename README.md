<h2 align="center">
    <a style="text-decoration:none;" href="https://github.com/tilamit/locking-strategies-.net-7.0">
      Locking Strategies With .NET Core 7.0
    </a>
    <br/>
</h2>

## Project Goal

To demonstrate locking strategies with .NET Core

<p align="center">
    <img src="https://i.ibb.co/4tZXdzD/optimistic-locking-img.png" alt="locking-strategies-.net-7.0" />
</p>

 <h4>Image Ref: 
  <a style="text-decoration:none;" href="https://www.coditation.com/">
      Coditation
  </a>
 </h4>

## Scenario

To know about locking, we have to know a bit about concurrency. In simple, concurrency means when two things happen at the same time. If we consider this in an application, then inventory management system would be a good example where users try to update same product quantity or human resource management system where two HR people try to update the same employee info.

Now this becomes a mess as one update gets overwritten by the another and at the same time, doesn’t provide consistency. To handle such scenario, we use the term locking. There are two types of locking, depending upon use cases these could be applied.

* Optimistic Locking
* Pessimistic Locking

**Optimistic Locking** - With this locking strategy, we confirm that whenever there are two or more users trying to update the same data at the same time, then the later update is blocked asking the user for retry or showing some kind of message. In this strategy, table row data isn’t locked, rather it maintains a binary value for reference to reflect the changes by previous users.

**Pessimistic Locking** - This lock actually does a row-level lock in the database table preventing any other read or update during that period. Whenever this operation gets executed successfully, then other users are able to go through that data for modifications.

## Built With

#### Environment & Development Tools：

* .NET Core Version: 7.0
* IDE: Visual Studio 2022
* Framework: .NET Core Web Api
* Backend: C# 11, ORM - Entity Framework Core Database First Approach 
* Database: MS SQL Server 2019

## Getting Started

Initially the project will restore all the required nuget packages for the project. If not, the following will help to make it done manually. 

For example, to install entity framework core and sql server package from nuget, the following command will download the specific version for the project.

### Prerequisites

* Nuget Package Manager

```sh
PM> Install-Package Microsoft.EntityFrameworkCore -Version 7.0.0
```

```sh
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.0
```

* SQL Server Database

In database table, add a column with timestamp datatype as follows and this will maintain a binary value to keep track of changes. This is required for optimistic locking.

For pessimistic locking, we omit the timestamp column and yep, that's all to get started.

<p align="center">
    <img src="https://i.ibb.co/L8hty9T/Screenshot-2024-04-22-180452-1.png" alt="locking-strategies-.net-7.0" />
</p>

* JMeter

To test the api and see the demo of optimistic locking, you can use JMeter that I used. Here's a link that you can follow - [JMeter Setup](https://loadium.com/blog/how-to-send-jmeter-post-requests).

It's pretty handy and you can download it from here - [Download JMeter](https://jmeter.apache.org/download_jmeter.cgi). 

When installation done, do the followings to work with the project as shown in the image:

Threads (Users) -> Thread Group             |  HTTP Post Request
:-------------------------:|:-------------------------:
![](https://i.ibb.co/PT9bpkt/Screenshot-2024-04-22-182345.png)  |  ![](https://i.ibb.co/jzh5Ft7/Screenshot-2024-04-22-182256.png)

## Authors

* **Amit Kanti Barua** - *Remote Software Engineer* - [Amit Kanti Barua](https://github.com/tilamit) - *Built ReadME Template*

## Acknowledgements

* [Amit Kanti Barua](https://github.com/tilamit)
