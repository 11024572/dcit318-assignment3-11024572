using HealthcareApp.App;

class Program
{
    static void Main()
    {
        var app = new HealthSystemApp();

        // i. Seed data
        app.SeedData();

        // ii. Build map (group prescriptions by PatientId)
        app.BuildPrescriptionMap();

        // iii. Print all patients
        app.PrintAllPatients();

        // iv. Pick a PatientId and print their prescriptions
        //     (you can change the ID to test others: 1, 2, or 3)
        app.PrintPrescriptionsForPatient(2);
    }
}
