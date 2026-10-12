namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    internal CourseRegistration( // to not called in the runner
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
}



public sealed class CourseRegistrationBuilder
{
    private readonly string _studentEmail;      
    private readonly string _courseCode;        
    private string? _accessMode;                
    private string? _groupCode;

    private string? _discountCode;              
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;

    public CourseRegistrationBuilder(string studentEmail, string courseCode)
    {
        _studentEmail = studentEmail;
        _courseCode = courseCode;
    }

    public CourseRegistrationBuilder LiveGroup(string groupCode)
    {
        _accessMode = "LiveGroup";
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder VideosOnly()
    {
        _accessMode = "VideosOnly";
        _groupCode = null;
        return this;
    }




    public CourseRegistrationBuilder WithDiscount(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder NotifyByWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string note)
    {
        _mentorNote = note;
        return this;
    }

    public CourseRegistrationBuilder StartingOn(DateOnly date)
    {
        _preferredStart = date;
        return this;
    }

    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail))
            throw new InvalidOperationException("Student email is required.");
        if (string.IsNullOrWhiteSpace(_courseCode))
            throw new InvalidOperationException("Course code is required.");
        if (_accessMode is null)
            throw new InvalidOperationException("Choose an access mode: call LiveGroup(...) or VideosOnly().");




        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup registration requires a group code.");
        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly registration cannot have a group code.");

        return new CourseRegistration(_studentEmail, _courseCode, _accessMode, _groupCode,
            _discountCode, _sendWhatsApp, _sendEmailWelcome, _mentorNote, _preferredStart);
    }
}





public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudent()
    {
        return new CourseRegistrationBuilder("Khaled@Simulation.com", "SEF-101")
            .LiveGroup("G1")
            .WithDiscount("EARLY10")
            .NotifyByWhatsApp()
            .SendEmailWelcome()
            .WithMentorNote("Needs evening slot")
            .StartingOn(new DateOnly(2026, 10, 1))
            .Build();
    }

    public static CourseRegistration CreateVideosOnly()
    {
        return new CourseRegistrationBuilder("AboTrika@ALahly.com", "22")
            .VideosOnly()
            .SendEmailWelcome()
            .Build();
    }


}
