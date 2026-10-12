using LibrarySystem;



Console.WriteLine("=== 1. Things that must not compile ===");
// Person p = new Person("P1", "X", "1");                      
// Member m = new Member("P1", "X", "1", 3, 0m);               
// Staff s = new Staff("S1", "X", "1", DateTime.Now, 1m, 0m);  
// LibraryItem i = new LibraryItem("C1", "X", 1m, 1, 1m);      
// student.FullName = "Hacker";                                
// student.Loans.Add(null);                                    
// book.IsOnLoan = true;                                       
// loan.Status = LoanStatus.Returned;                          
Console.WriteLine("(see the commented lines in Program.cs)\n");


// ---------- Setup ----------
DateTime today = new DateTime(2026, 10, 1);
Librarian librarian = new Librarian("S1", "Layla Hassan", "0100-111", new DateTime(2020, 1, 5), 3000m);
HeadLibrarian head = new HeadLibrarian("S2", "Omar Nabil", "0100-222", new DateTime(2015, 3, 1), 4000m);
Shelver shelver = new Shelver("S3", "Sara Adel", "0100-333", new DateTime(2022, 6, 10), 2500m, "Fiction");

Book book = new Book("B-001", "Clean Code", 1.00m);
Dvd dvd = new Dvd("D-001", "Inception", 1.00m);
Magazine magazine = new Magazine("M-001", "National Geographic", 1.00m);
Book withdrawnBook = new Book("B-002", "Old Atlas", 1.00m);
Book book3 = new Book("B-003", "Book 3", 1.00m);
Book book4 = new Book("B-004", "Book 4", 1.00m);
Book book5 = new Book("B-005", "Book 5", 1.00m);

StudentMember student = new StudentMember("M-100", "Ali Student", "0111-100");
PremiumMember premium = new PremiumMember("M-200", "Mona Premium", "0111-200", 20m);

// ---------- Borrowing rules ----------
Console.WriteLine("=== 2. Borrowing rules ===");
head.Withdraw(withdrawnBook);
try { student.Borrow(withdrawnBook, today); }
catch (Exception ex) { Console.WriteLine("Withdrawn item rejected: " + ex.Message); }

student.Borrow(book, today);
try { premium.Borrow(book, today); }
catch (Exception ex) { Console.WriteLine("Already on loan rejected: " + ex.Message); }

student.Borrow(book3, today);
student.Borrow(book4, today);
try { student.Borrow(book5, today); }
catch (Exception ex) { Console.WriteLine("4th item rejected: " + ex.Message); }

// ----------  staff ----------
Console.WriteLine("\n=== 3. Monthly pay ===");
List<Staff> staffList = new List<Staff> { librarian, head, shelver };
foreach (Staff member in staffList)
{
    Console.WriteLine($"{member.FullName} ({member.GetType().Name}): {member.GetMonthlyPay():0.00}");
}

// ----------  items ----------
Console.WriteLine("\n=== 4. Loan period and daily late fee ===");
List<LibraryItem> items = new List<LibraryItem> { book, dvd, magazine };
foreach (LibraryItem item in items)
{
    Console.WriteLine($"{item.Title} ({item.GetType().Name}): period {item.LoanPeriodDays} days, daily late fee {item.GetDailyLateFee():0.00}");
}

// ---------- Late return ----------
Console.WriteLine("\n=== 5. Premium member returns a DVD 5 days late ===");
Loan dvdLoan = premium.Borrow(dvd, today);
librarian.ProcessReturn(dvdLoan, dvdLoan.DueDate.AddDays(5));
Console.WriteLine($"Due date:       {dvdLoan.DueDate:yyyy-MM-dd}");
Console.WriteLine($"Late fee:       {dvdLoan.LateFee:0.00}");
Console.WriteLine($"Reading points: {premium.ReadingPoints}");

// ---------- Illegal status changes ----------
Console.WriteLine("\n=== 6. Illegal status changes ===");
try { librarian.ProcessReturn(dvdLoan, today.AddDays(20)); }
catch (Exception ex) { Console.WriteLine("Double return rejected: " + ex.Message); }

try { librarian.MarkAsLost(dvdLoan); }
catch (Exception ex) { Console.WriteLine("Lost-after-return rejected: " + ex.Message); }

// ---------- Other validation ----------
Console.WriteLine("\n=== 7. Other validation ===");
try { librarian.GiveRaise(0); }
catch (Exception ex) { Console.WriteLine("Zero raise rejected: " + ex.Message); }

try { head.ChangeLateFee(book, -2m); }
catch (Exception ex) { Console.WriteLine("Negative fee rejected: " + ex.Message); }

try { new StudentMember("", "No Id", "123"); }
catch (Exception ex) { Console.WriteLine("Empty ID rejected: " + ex.Message); }

Loan magazineLoan = premium.Borrow(magazine, today);
try { librarian.ProcessReturn(magazineLoan, today.AddDays(-1)); }
catch (Exception ex) { Console.WriteLine("Return before borrow date rejected: " + ex.Message); }

shelver.Reassign("Children");
Console.WriteLine($"Shelver reassigned to: {shelver.Section}");





