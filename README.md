## Assessment

Complete a small full stack solution to do tax calculations using .NET and MVC Razor and do some basic CRUD
operations on Sqlite using Entity Framework (localdb provided with assignment).
A previous junior developer started this project but was unable to complete it.
It is up to you to get it functioning as per the requirement, please feel free to add, remove or change whatever you need to.
Once you have completed the task, please zip your repo & share it with TA Specialist you are working with via a Google Drive / similar link

### A few pointers:

* Make sure you understand how progressive tax works
* Start with the API and ensure that it is functioning as required before moving on to the web project.
* Please keep performance in mind in your implementation,for example how would your application handle 1 million progresive calculations a day on limited hardware?
* Besides completing the test and getting it to work, and accuracy is important, it is also a chance to show the senior developers your understanding of a good framework so
  * Adhere to the SOLID principals
  * Complete the existing unit tests
  * Avoid scaffolding / Generated Code
  * Clean well-formatted code
  * Do not hardcode the calculators
  * Do not change the database, the application must use Sqlite
  * Test cases for calculators might not be correct

### Task brief:

You have been briefed to complete a tax calculator for an individual. The application will take annual income and postal code.

**Each postal code is linked to a type of Tax calculation:**

| Postal Code | Tax Calculation Type |
|-------------|----------------------|
| 7441        | Progressive          |
| A100        | Flat Value           |
| 7000        | Flat rate            |
| 1000        | Progressive          |

**The progressive tax is calculated based on this table (be sure you understand how a progressive calculation works):**

| Rate | From      | To     | 
|------|-----------|--------|
| 10%  | 0         | 8350   |
| 15%  | \> 8350      | 33950  |    
| 25%  | \> 33950     | 82250  |                      
| 28%  | \> 82250     | 171550 |  
| 33%  | \> 171550    | 372950 | 
| 35%  | \> 372950 | 0      |


**The flat value:**
* 10000 per year
* Else if the individual earns less than 200000 per year the tax will be at 5%

**The flat rate:**
* All users pay 17.5% tax on their income

**Approach:**
* Use SOLID principles
* Use appropriate Design Patterns
* IOC/Dependency Injection
* Allow for entering the Postal code and annual income on the front end and submitting
* Store the calculated value to Sqllite with date/time and the two fields entered
* Security is not required but feel free to show off
* Server side should be REST API’s

**Before submitting your solution, please ensure the following:**
* Clean your solution to reduce the submitted file size.
* Do not include the ***bin*** and ***obj*** directories in your submission.



## Refactoring and Improvements

### Architecture Enhancements

* I refactored the code by applying Clean Architecture principles, introducing a new Application Layer to separate business logic from the API layer. Previously, the API layer contained business logic, so I moved these operations to the Application Layer and refactored the code to include reusable services.

* I implemented the Mediator Pattern using only interfaces, making it easier to resolve API requests and determine which handler should process them.

* I introduced repositories for all services to correctly separate data access from service implementations, ensuring better maintainability and adherence to SOLID principles.


### Potential Improvements

* The Services Layer could be renamed to Infrastructure Layer to better reflect its role in the architecture.

* Validation could have been added at multiple levels:
    * At the API layer to ensure incoming requests meet requirements.
    * At the Data Access layer using Value Object principles to enforce constraints and consistency.

* Error Handling could be improved by:
    * Implementing an Exception class to throw specific exceptions when validation fails.
    * Creating a middleware to handle all exceptions centrally and return meaningful error messages based on exception types.

### Security Considerations

* Due to time constraints, security features were not fully implemented. However, I planned to:
  * Introduce a User Context for registering and managing users.
  * Implement Authentication and Authorization within the API to control access.

### Frontend (Web Layer)
* I used basic Razor Views with a simple UI, focusing on core functionality rather than advanced design.

* Possible improvements:
  * Implementing CRUD operations for additional services.
  * Applying authorization to restrict actions based on user roles.
  * Enhancing the UI with modals to prompt users for confirmation before deleting history records.

### Testing

* My testing approach was minimal. I could have:
  * Written comprehensive tests for all services.
  * Verified the Calculator Factory Pattern creation process.

