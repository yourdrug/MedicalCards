using Data_acccess_layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Features>  Features { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Research> Researches { get; set; }

        public AppContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=medicalcards;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionOfMedicines>().HasKey(e => new { e.AppointmentId, e.MedicinesId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointment)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointment)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Diagnosis>()
                .HasOne(d => d.Doctor)
                .WithMany(p => p.Diagnosis)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Diagnosis>()
                .HasOne(d => d.Patient)
                .WithOne(p => p.Diagnosis)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}