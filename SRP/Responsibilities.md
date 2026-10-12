==================================================================

1-AppointmentDesk:

1. have the business opening hours
2. Finding open slots, and booking
3. ICS calendar generator
4. Sendeing SMS

problem: policy, calendar, and sms .
so many things to change in one class ,if one function crashes everything will stop!

==================================================================

2-CheckoutBasket:

1. Have the orderlines and Calculate subtotal 
2. Read coupon text and Claculate discount
3. Checking giftwrap and Applying giftwrap fee
4. Send gift message card
5. Authorize Payment

problem: send message,authorize the payment, all the calculation . all of them in one place , if sending message failed the calculation and everything will crash.

==================================================================

3-CourseEnrollmentDesk:

1. Course Policy like capacity and Tuition fee
2. Register students and get their positions in the waitlist
3. Send Welcome packet markdown
4. Calculate Tution Fee
5. Promote some students from waitlist to be seated

problem: Policy numbers, registering, send welcome ,calculate fee.
all of them different responsibilities in one place, change in welcome text will stop the regestirng process!

==================================================================

4-GradeBook:

1. Record new scores for students
2. Calculate Average Score for student
3. Return Academic Policy as letter grades
4. Decides honor Roll or not 
5. Print transcript text
6. Export CSV

problem: Record new scores,calculate,export csv , ...
all of them in one class , change in formatting will stop average calculation or record scores.

==================================================================

5-KitchenTicket:

1. Add items
2. Detect Allergens
3. Estimate Ready time
4. Print Thermal Ticket
5. Choosing suitable lane

problem: changing in allergens logic Will stop adding items also, so many different responsibilities in one place.

==================================================================

6-LoanDesk:

1. Have Lone Application Data
2. Calculate RsikScore
3. Check Eligble or not
4. Have Required Docs
5. Print Decision Letter
6. Print CSV Row

prblem : 6 different responsibilities in one class, changing in csv format will stop the whole process,change in claculate logic will stop printing letters.

==================================================================

7-SubscriptionBilling:

1. Have subscription data and failed payment count
2. Calculate proration
3. Calculate invoice numbers
4. Writing the dunning email
5. Writing the ledger journal line

problem : change in writing email will crash invoice numbers calc.
and there is side effect here, both DunningEmail and LedgerJournalLine call the nextinvoicenumber while building the text!

==================================================================

8-SupportTicket:

1. Have ticket data 
2. Choosing the priority from keywords in the text
3. Calculating the SLA deadline and checking is breached or not
4. Draft public reply
5. Writing the internal escalation note

problem: changing in writing format will stopped the whole process.

==================================================================

9-WardBoard:

1. Assign patient to bed
2. Calculating acuity score 
3. Writing the nurse handoff note
4. Exporting the census CSV

problem: claculate logic can affected if csv had an issue

==================================================================

10-WarehousePickList:

1. Holding the needed lines
2. Allocate stock
3. Ordering the walking path
4. Writing picker script
5. Producing WMS XML

problem: Allocation logic will affected if script format had a cahnge

==================================================================

