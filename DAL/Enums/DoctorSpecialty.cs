using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Enums
{
    public enum DoctorSpecialty
    {
        Allergist = 0,
        Anesthesiologist,
        Cardiologist,
        [Display(Name = "Colon and Rectal Surgeon")]
        ColonAndRectalSurgeon,
        [Display(Name = "Critical Care Medicine Specialist")]
        CriticalCareMedicineSpecialist,
        Dermatologist,
        [Display(Name = "Emergency Medicine Specialist")]
        EmergencyMedicineSpecialist,
        Endocrinologist,
        [Display(Name = "Family Physician")]
        FamilyPhysician,
        Gastroenterologist,
        [Display(Name = "Geriatric Medicine Specialist")]
        GeriatricMedicineSpecialist,
        Hematologist,
        [Display(Name = "Infectious Disease Specialist")]
        InfectiousDiseaseSpecialist,
        Immunologist,
        Internist,
        [Display(Name = "Medical Geneticist")]
        MedicalGeneticist,
        Nephrologist,
        Neurologist,
        [Display(Name = "Obstetricians and Gynecologist")]
        ObstetricianAndGynecologist,
        Oncologist,
        Ophtalmologist,
        Osteopath,
        Otolaryngologist,
        Pathologist,
        Pediatrician,
        Physiatrist,
        [Display(Name = "Plastic Surgeon")]
        PlasticSurgeon,
        Podiatrist,
        Psychiatrist,
        Pulmonologist,
        [Display(Name = "Sleep Medicine Specialist")]
        Radiologist,
        SleepMedicineSpecialist,
        [Display(Name = "Sports Medicine Specialist")]
        SportsMedicineSpecialist,
        [Display(Name = "General Surgeon")]
        GeneralSurgeon,
        Urologist
    }
}
