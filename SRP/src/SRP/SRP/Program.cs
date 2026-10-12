using SrpLab.AppointmentDesk;
using SrpLab.CheckoutBasket;
using SrpLab.CourseEnrollmentDesk;
using SrpLab.GradeBook;
using SrpLab.KitchenTicket;
using SrpLab.LoanDesk;
using SrpLab.SubscriptionBilling;
using SrpLab.SupportTicket;
using SrpLab.WardBoard;
using SrpLab.WarehousePickList;

namespace SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SrpLab — 10 intentional SRP violations (refactored)");
            Console.WriteLine("=================================================");

             
            Console.WriteLine("=================================================");
            Console.WriteLine("1.WardBoard");
            Console.WriteLine("=================================================");

            var pager = new PagerAlertLog();
            var ward = new WardBoard(new AcuityScorer(), pager);
            ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
            Console.WriteLine(new HandoffNoteWriter().BuildHandoffNote(ward, 1));
            Console.WriteLine(string.Join(" | ", pager.DrainPagerLog()));

            // 


            Console.WriteLine("=================================================");
            Console.WriteLine("2. CheckoutBasket");
            Console.WriteLine("=================================================");

            var basket = new Basket();
            basket.AddLine("SKU-1", 40m, 2);
            basket.ApplyCouponText("SAVE10");
            basket.EnableGiftWrap();
            var calculation = new BasketCalculation( new GiftWrapPolicy(),new CouponDiscount());
            var basketTotal = calculation.CalculateGrandTotal(basket);
            Console.WriteLine($"basket total={basketTotal} auth={new PaymentAuthorizer().Authorize(basket, basketTotal, "4242")}");

            // 

            Console.WriteLine("=================================================");
            Console.WriteLine("3. SupportTicket");
            Console.WriteLine("=================================================");

            var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me",
                                           DateTimeOffset.UtcNow, new PriorityClassifier());
            var deadline = new SlaPolicy().Deadline(ticket, ticket.Priority);
            Console.WriteLine(new PublicReplyDrafter().Draft(ticket.Id, ticket.Priority, "Nora", deadline));



            // 



            Console.WriteLine("=================================================");
            Console.WriteLine("4. LoanDesk");
            Console.WriteLine("=================================================");
            
            var application = new LoanApplication(60_000m, 640, 4, hasCollateral: false);
            var risk = new RiskScorer().Score(application);
            var eligible = new EligibilityPolicy().IsEligible(application, risk);
            var documents = new RequiredDocumentsChecklist().Get(application, eligible);
            Console.WriteLine(new DecisionLetterWriter().Write("Omar", application, eligible, risk, documents));



            // 


            Console.WriteLine("=================================================");
            Console.WriteLine("5. CourseEnrollmentDesk");
            Console.WriteLine("=================================================");


            var course = new Course("SEF-101", capacity: 1);
            Console.WriteLine(course.Register("a@mail.com"));
            Console.WriteLine(course.Register("b@mail.com"));
            Console.WriteLine(new WelcomeMarkdown().Write(course, "b@mail.com", "Bea"));


            // 


            Console.WriteLine("=================================================");
            Console.WriteLine("6. KitchenTicket");
            Console.WriteLine("=================================================");


            var kitchenOrder = new KitchenOrder();
            kitchenOrder.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
            var allergens = new AllergenDetector().Detect(kitchenOrder);
            var eta = new ReadyTimeEstimator().Estimate(kitchenOrder, allergens.Count > 0, openStations: 2);
            Console.WriteLine(new ThermalTicketPrinter().Print(42, kitchenOrder, eta, allergens));

            // 


            Console.WriteLine("=================================================");
            Console.WriteLine("7. SubscriptionBilling");
            Console.WriteLine("=================================================");

            var sub = new Subscription("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
            sub.RegisterFailedPayment();
            var proration = new ProrationCalculator();
            var invoices = new InvoiceNumberGenerator();
            var amount = proration.Prorate(sub, sub.PeriodStart);
            var invoice = invoices.Next(sub.PeriodStart);
            Console.WriteLine(new DunningEmailWriter().Write("Sara", new DateOnly(2026, 9, 20), sub.FailedPayments, amount, invoice));




            // 

            Console.WriteLine("=================================================");
            Console.WriteLine("8. WarehousePickList");
            Console.WriteLine("=================================================");


            var pick = new WarehousePickList();
            pick.AddNeed("BOLT", "A", 3, 10, 7);
            pick.AddNeed("NUT", "B", 1, 5, 5);
            Console.WriteLine(new PickerScriptWriter(new StockAllocator(), new WalkingPathPlanner()).PickerScript(pick));

            // 



            Console.WriteLine("=================================================");
            Console.WriteLine("9. GradeBook");
            Console.WriteLine("=================================================");


            var scoreBook = new ScoreBook();
            scoreBook.Record("s1", 92);
            scoreBook.Record("s1", 88);
            var averager = new CalculateGradeAverage();
            var letters = new LetterGradePolicy();
            var honorPolicy = new HonorRollPolicy();
            var avg = averager.Average(scoreBook, "s1");
            var letter = letters.Letter(avg);
            Console.WriteLine(new TranscriptWriter().Write("s1", "Ali", avg, letter, honorPolicy.Qualifies(avg, letter)));

            // 



            Console.WriteLine("=================================================");
            Console.WriteLine("10. AppointmentDesk");
            Console.WriteLine("=================================================");


            var hours = new AppointmentHoursPolicy(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
            var scheduler = new SlotScheduler(hours);
            var slot = scheduler.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
            if (slot is null) throw new InvalidOperationException("no slot");
            scheduler.TryBook(slot.Value);
            Console.WriteLine(new SmsReminder().SendReminder(slot.Value, "0100"));

            Console.WriteLine("Done Alhamdulillah. Now split responsibilities but without breaking behavior.");


        }
    }
}
