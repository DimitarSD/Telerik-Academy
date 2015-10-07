##1. What database models do you know?

- ####Hierarchial model (tree) 
*The data is organized into a tree-like structure. The data is stored as records which are connected to one another through links.*

- ####Network / graph
*It is a database model conceived as a flexible way of representing objects and their relationships.*

- ####Relational (tables)
*In the relational model of a database, all data is represented in terms of tuples, grouped into relations.*

- ####Object-oriented
*The information is represented in the form of objects as used in object-oriented programming. Object databases are different from relational databases which are table-oriented. Object-relational databases are a hybrid of both approaches.*


##2. Which are the main functions performed by a Relational Database Management System (RDBMS)?

- Creating, altering, deleting tables and relationships between them.
- Adding, changing, deleting, searching and retrieving of data.
- Transaction management
- Support for the SQL language


##3. Define what is "table" in database terms.
A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.


##4. Explain the difference between a primary and a foreign key.
Primary Key: It will not allow "Null values" and "Duplicate values"
Foreign Key: It will allow "Null values" and "Duplicte values" and it refers to a primary key in anoter table.


##5. Explain the different kinds of relationships between tables in relational databases.

There are three types of relationships:

**One-to-one**: 
*Both tables can have only one record on either side of the relationship. Each primary key value relates to only one (or no) record in the related table. They're like spouses you may or may not be married, but if you are, both you and your spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.*

**One-to-many**: 
*The primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.*

**Many-to-many**: 
*Each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.*


##6. When is a certain database schema normalized? What are the advantages of normalized databases?

- Normalization of the relational schema removes repeating data
- Normalization involves decomposing a table into less redundant (and smaller) tables but without losing information


##7. What are database integrity constraints and when are they used?

- Integrity constraints are used to ensure accuracy and consistency of data in a relational database. 


##8. Point out the pros and cons of using indexes in a database.

**Pros**:
- Speed up searching of values in a certain column or group of columns.

**Cons**:
- Adding and deleting records in indexed tables is slower.


##9. What's the main purpose of the SQL language?

Management of data stored in a relational database management system. It supports distributed databases, offering users great flexibility.


##10. What are transactions used for? Give an example.

A transaction is a unit of work that is performed against a database. Transactions are units or sequences of work accomplished in a logical order, whether in a manual fashion by a user or automatically by some sort of a database program.

A transaction is the propagation of one or more changes to the database. For example, if you are creating a record or updating a record or deleting a record from the table, then you are performing transaction on the table. It is important to control transactions to ensure data integrity and to handle database errors.


##11. What is a NoSQL database?

- A NoSQL database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases. Motivations for this approach include simplicity of design, horizontal scaling, and finer control over availability.


##12. Explain the classical non-relational data models.

- A non-relational database is a database that does not incorporate the table/key model that relational database management systems (RDBMS) promote.

-  These kinds of databases require data manipulation techniques and processes designed to provide solutions to big data problems that big companies face. 

- The most popular emerging non-relational database is called NoSQL (Not Only SQL).


##13. Give few examples of NoSQL databases and their pros and cons.

**Databases**:
- Cassandra (Distributed wide-column database)
- MongoDB (Mature and powerful JSON-Document database)
- CouchDB (JSON-based document database with REST API)
- Redis (Ultra-fast in-memory data structures server)
- H-Base
- etc ...

**Models**: 
- Document model
- Associative (Key-value) model
- Hierarchical key-value model
- Wide-column model
- Object model
- etc ...

**Pros**: 
- Support CRUD operations
- Support Indexing and querying
- Support concurrency and transactions
- Highly optimized for append / retrieve
- Great performance and scalability
- etc ...

**Cons**:
- Difficult administration and support
- etc ... 