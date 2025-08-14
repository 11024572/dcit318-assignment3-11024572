using System;
using System.Collections.Generic;
using HealthcareApp.Data;
using HealthcareApp.Models;

namespace HealthcareApp.App
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();

        // Key = PatientId, Value = that patient's prescriptions
        private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

        // --- Requirement: SeedData ---
        public void SeedData()
        {
            // Patients (2–3)
            _patientRepo.Add(new Patient(1, "Ama Mensah", 28, "Female"));
            _patientRepo.Add(new Patient(2, "Kwame Owusu", 41, "Male"));
            _patientRepo.Add(new Patient(3, "Akosua Boateng", 35, "Female"));

            // Prescriptions (4–5) with valid PatientIds
            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin 500mg", DateTime.Today.AddDays(-6)));
            _prescriptionRepo.Add(new Prescription(102, 2, "Ibuprofen 400mg", DateTime.Today.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(103, 1, "Cetirizine 10mg", DateTime.Today.AddDays(-1));
            _prescriptionRepo.Add(new Prescription(104, 3, "Metformin 500mg", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(105, 2, "Paracetamol 1g", DateTime.Today));
        }

        // --- Requirement: BuildPrescriptionMap (group by PatientId) ---
        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();

            foreach (var rx in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.TryGetValue(rx.PatientId, out var list))
                {
                    list = new List<Prescription>();
                    _prescriptionMap[rx.PatientId] = list;
                }
                list.Add(rx);
            }
        }

        // --- Requirement: PrintAllPatients ---
        public void PrintAllPatients()
        {
            Console.WriteLine("=== Patients ===");
            foreach (var p in _patientRepo.GetAll())
                Console.WriteLine(p);
            Console.WriteLine();
        }

        // --- Requirement: GetPrescriptionsByPatientId using the map ---
        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.TryGetValue(patientId, out var list)
                ? new List<Prescription>(list)
                : new List<Prescription>();
        }

        // --- Requirement: PrintPrescriptionsForPatient(int id) ---
        public void PrintPrescriptionsForPatient(int id)
        {
            Console.WriteLine($"=== Prescriptions for PatientId {id} ===");

            var patient = _patientRepo.GetById(p => p.Id == id);
            if (patient is null)
            {
                Console.WriteLine("No such patient.\n");
                return;
            }

            var rxs = GetPrescriptionsByPatientId(id);
            if (rxs.Count == 0)
            {
                Console.WriteLine("No prescriptions found.\n");
                return;
            }

            foreach (var rx in rxs)
                Console.WriteLine(rx);
            Console.WriteLine();
        }
    }
}
