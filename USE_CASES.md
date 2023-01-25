## Use Case 1: Add New Employee
A new employee is added by the receipt of an AddEmp transaction. This transaction contains the employee's name, address, and assigned employee number. The transaction has three forms: 

1. AddEmp <EmpID> "<name>" "<address>" H <hrly-rate> 
2. AddEmp <EmpID> "<name>" "<address>" S <mtly-slry> 
3. AddEmp <EmpID> "<name>" "<address>" C <mtly-slry> <comm-rate> 

The employee record is created with its fields assigned appropriately.

### Alternatives: An error in the transaction structure
If the transaction structure is inappropriate, it is printed out in an error message, and no action is taken.

## Use Case 2: Deleting an Employee
Employees are deleted when a DelEmp TRansaction is received. The form of this transaction is as follows:

DelEmp <EmpID>

When this transaction is received, the appropriate employee record is deleted.

### Alternative: Invalid or unknown
EmpID If the <EmpID> field is not structured correctly or does not refer to a valid employee record, the transaction is printed with an error message, and no other action is taken.

## Use Case 3: Post a Time Card
On receipt of a TimeCard transaction, the system will create a time card record and associate it with the appropriate employee record:

TimeCard <empid> <date> <hours>

### Alternative 1: The selected employee is not hourly
The system will print an appropriate error message and take no further action.

### Alternative 2: An error in the transaction structure
The system will print an appropriate error message and take no further action.

## Use Case 4: Posting a Sales Receipt
On receipt of the SalesReceipt transaction, the system will create a new sales-receipt record and associate it with the appropriate commissioned employee.

SalesReceipt <EmpID> <date> <amount>

### Alternative 1: The selected employee is not commissioned
The system will print an appropriate error message and take no further action.

### Alternative 2: An error in the transaction structure
The system will print an appropriate error message and take no further action.

## Use Case 5: Posting a Union Service Charge

On receipt of this transaction, the system will create a service-charge record and associate it with the appropriate union member:

ServiceCharge <memberID> <amount>

### Alternative: Poorly formed transaction

If the transaction is not well formed or if the <memberID> does not refer to an existing union member, the transaction is printed with an appropriate error message.

## Use Case 6: Changing Employee Details
On receipt of this transaction, the system will alter one of the details of the appropriate employee record. This transaction has several possible variations:

ChgEmp <EmpID> Name <name>
Change employee name

ChgEmp <EmpID> Address <address>
Change employee address

ChgEmp <EmpID> Hourly <hourlyRate>
Change to hourly

ChgEmp <EmpID> Salaried <salary>
Change to salaried

ChgEmp <EmpID> Commissioned <salary> <rate>
Change to commissioned

ChgEmp <EmpID> Hold
Hold paycheck

ChgEmp <EmpID> Direct <bank> <account>
Direct deposit

ChgEmp <EmpID> Mail <address>
Mail paycheck

ChgEmp <EmpID> Member <memberID> Dues <rate> 
Put employee in union

ChgEmp <EmpID> NoMember
Cut employee from union

### Alternative: Transaction Errors
If the structure of the transaction is improper, <EmpID> does not refer to a real employee, <memberID> already refers to a member, print a suitable error, and take no further action.

## Use Case 7: Run the Payroll for Today
On receipt of the payday transaction, the system finds all those employees who should be paid on the specified date. The system then determines how much they are owed and pays them according to their selected payment method. An audit-trail report is printed showing the action taken for each employee:

Payday <date>