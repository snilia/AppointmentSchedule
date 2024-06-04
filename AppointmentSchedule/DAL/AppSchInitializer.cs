using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.DAL
{
    public class AppSchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppSchContext>
    //public class AppSchInitializer : System.Data.Entity.DropCreateDatabaseAlways<AppSchContext>
    {
        protected override void Seed(AppSchContext context)
        {
            //workers, 1-4
            var workers = new List<Worker>
            {
                new Worker{FirstName="Doctor",LastName="Fischer",PhoneNumber="0545540001",IsActive=true},
                new Worker{FirstName="John",LastName="Gone",PhoneNumber="0545540002",IsActive=false}, //the doctor that is not working anymore
                new Worker{FirstName="Ab",LastName="Sent",PhoneNumber="0545540004",IsActive=false}, //shinanit not working anymore
                new Worker{FirstName="Shin",LastName="Annit",PhoneNumber="0545540003",IsActive=true}
                
            };
            workers.ForEach(s => context.Workers.Add(s));
            context.SaveChanges();
            {/*
            var clients = new List<Client>
            {
                new Client{FirstName="ACFirst1",LastName="ACLast1",PhoneNumber="0526990901"},
                new Client{FirstName="ACFirst2",LastName="ACLast2",PhoneNumber="0526990902"},
                new Client{FirstName="ACFirst3",LastName="ACLast3",PhoneNumber="0526990903"},
                new Client{FirstName="ACFirst4",LastName="ACLast4",PhoneNumber="0526990904"},
                new Client{FirstName="ACFirst5",LastName="ACLast5",PhoneNumber="0526990905"},
                new Client{FirstName="ACFirst6",LastName="ACLast6",PhoneNumber="0526990906"},
                new Client{FirstName="ACFirst7",LastName="ACLast7",PhoneNumber="0526990907"}
            };

            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var workers = new List<Worker>
            {
                new Worker{FirstName="WAFirst1",LastName="WALast1",PhoneNumber="0545540001",IsActive=true},
                new Worker{FirstName="WMFirst2",LastName="WMLast2",PhoneNumber="0545540002",IsActive=true},
                new Worker{FirstName="WMFirst3",LastName="WMLast3",PhoneNumber="0545540003",IsActive=true},
                new Worker{FirstName="WFirst4",LastName="WLast4",PhoneNumber="0545540004",IsActive=false},
                new Worker{FirstName="WFirst5",LastName="WLast5",PhoneNumber="0545540005",IsActive=false},
                new Worker{FirstName="WFirst6",LastName="WLast6",PhoneNumber="0545540006",IsActive=true},
                new Worker{FirstName="WFirst7",LastName="WLast7",PhoneNumber="0545540007",IsActive=true}
            };
            workers.ForEach(s => context.Workers.Add(s));
            context.SaveChanges();
            */
            }

            //clients, 5-45
            var moreclients = new List<Client>
            {
                new Client{FirstName="Jessica",LastName="Moore",PhoneNumber="0526990908"},
                new Client{FirstName="Chris",LastName="Taylor",PhoneNumber="0526990909"},
                new Client{FirstName="Amanda",LastName="Anderson",PhoneNumber="0526990910"},
                new Client{FirstName="Matthew",LastName="Thomas",PhoneNumber="0526990911"},
                new Client{FirstName="Ashley",LastName="Jackson",PhoneNumber="0526990912"},
                new Client{FirstName="Joshua",LastName="White",PhoneNumber="0526990913"},
                new Client{FirstName="Jennifer",LastName="Harris",PhoneNumber="0526990914"},
                new Client{FirstName="Daniel",LastName="Martin",PhoneNumber="0526990915"},
                new Client{FirstName="Megan",LastName="Thompson",PhoneNumber="0526990916"},
                new Client{FirstName="Andrew",LastName="Garcia",PhoneNumber="0526990917"},
                new Client{FirstName="Lauren",LastName="Martinez",PhoneNumber="0526990918"},
                new Client{FirstName="Ryan",LastName="Robinson",PhoneNumber="0526990919"},
                new Client{FirstName="Rachel",LastName="Clark",PhoneNumber="0526990920"},
                new Client{FirstName="Brandon",LastName="Rodriguez",PhoneNumber="0526990921"},
                new Client{FirstName="Olivia",LastName="Lewis",PhoneNumber="0526990922"},
                new Client{FirstName="Justin",LastName="Lee",PhoneNumber="0526990923"},
                new Client{FirstName="Stephanie",LastName="Walker",PhoneNumber="0526990924"},
                new Client{FirstName="Nathan",LastName="Hall",PhoneNumber="0526990925"},
                new Client{FirstName="Hannah",LastName="Allen",PhoneNumber="0526990926"},
                new Client{FirstName="Ethan",LastName="Young",PhoneNumber="0526990927"},
                new Client{FirstName="Lauren",LastName="Hernandez",PhoneNumber="0526990928"},
                new Client{FirstName="Christian",LastName="King",PhoneNumber="0526990929"},
                new Client{FirstName="Natalie",LastName="Wright",PhoneNumber="0526990930"},
                new Client{FirstName="Benjamin",LastName="Lopez",PhoneNumber="0526990931"},
                new Client{FirstName="Emma",LastName="Hill",PhoneNumber="0526990932"},
                new Client{FirstName="Alexander",LastName="Scott",PhoneNumber="0526990933"},
                new Client{FirstName="Samantha",LastName="Green",PhoneNumber="0526990934"},
                new Client{FirstName="Tyler",LastName="Adams",PhoneNumber="0526990935"},
                new Client{FirstName="Victoria",LastName="Baker",PhoneNumber="0526990936"},
                new Client{FirstName="Aaron",LastName="Gonzalez",PhoneNumber="0526990937"},
                new Client{FirstName="Abigail",LastName="Nelson",PhoneNumber="0526990938"},
                new Client{FirstName="Jonathan",LastName="Carter",PhoneNumber="0526990939"},
                new Client{FirstName="Brianna",LastName="Mitchell",PhoneNumber="0526990940"},
                new Client{FirstName="Samuel",LastName="Perez",PhoneNumber="0526990941"},
                new Client{FirstName="Victoria",LastName="Roberts",PhoneNumber="0526990942"},
                new Client{FirstName="Dylan",LastName="Turner",PhoneNumber="0526990943"},
                new Client{FirstName="Sophia",LastName="Phillips",PhoneNumber="0526990944"},
                new Client{FirstName="Zachary",LastName="Campbell",PhoneNumber="0526990945"},
                new Client{FirstName="Grace",LastName="Parker",PhoneNumber="0526990946"},
                new Client{FirstName="Logan",LastName="Evans",PhoneNumber="0526990947"},
                new Client{FirstName="Alyssa",LastName="Edwards",PhoneNumber="0526990948"},
                new Client{FirstName="Jack",LastName="Collins",PhoneNumber="0526990949"},
                new Client{FirstName="Elizabeth",LastName="Stewart",PhoneNumber="0526990950"}
            };
            moreclients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            //appointments

            var appointments = new List<Appointment>
            {
                new Appointment{ClientID=6, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,03,10,00,00), LengthInHours=1, TextBox="Appointment 2"},
                new Appointment{ClientID=10, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,06,11,30,00), LengthInHours=2, TextBox="Appointment 3"},
                new Appointment{ClientID=15, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,01,10,13,00,00), LengthInHours=3, TextBox="Appointment 4"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,01,15,09,00,00), LengthInHours=4, TextBox="Appointment 5"},
                new Appointment{ClientID=22, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,17,14,00,00), LengthInHours=1, TextBox="Appointment 6"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,21,10,00,00), LengthInHours=2, TextBox="Appointment 7"},
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,25,16,00,00), LengthInHours=3, TextBox="Appointment 8"},
                new Appointment{ClientID=12, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,02,01,09,00,00), LengthInHours=1, TextBox="Appointment 9"},
                new Appointment{ClientID=17, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,05,14,30,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=24, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,02,10,11,00,00), LengthInHours=3, TextBox="Appointment 11"},
                new Appointment{ClientID=27, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,14,15,00,00), LengthInHours=4, TextBox="Appointment 12"},
                new Appointment{ClientID=33, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,20,10,00,00), LengthInHours=2, TextBox="Appointment 13"},
                new Appointment{ClientID=35, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,02,25,13,00,00), LengthInHours=1, TextBox="Appointment 14"},
                new Appointment{ClientID=40, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,01,11,30,00), LengthInHours=2, TextBox="Appointment 15"},
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,07,09,00,00), LengthInHours=3, TextBox="Appointment 16"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,03,11,14,00,00), LengthInHours=4, TextBox="Appointment 17"},
                new Appointment{ClientID=19, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,15,10,00,00), LengthInHours=2, TextBox="Appointment 18"},
                new Appointment{ClientID=23, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,20,15,00,00), LengthInHours=3, TextBox="Appointment 19"},
                new Appointment{ClientID=29, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,03,25,09,00,00), LengthInHours=1, TextBox="Appointment 20"},
                new Appointment{ClientID=34, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,31,14,30,00), LengthInHours=2, TextBox="Appointment 21"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,05,11,00,00), LengthInHours=3, TextBox="Appointment 22"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,04,10,15,00,00), LengthInHours=4, TextBox="Appointment 23"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,15,10,00,00), LengthInHours=2, TextBox="Appointment 24"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,20,13,00,00), LengthInHours=3, TextBox="Appointment 25"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,04,25,09,00,00), LengthInHours=1, TextBox="Appointment 26"},
                new Appointment{ClientID=38, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,01,14,30,00), LengthInHours=2, TextBox="Appointment 27"},
                new Appointment{ClientID=11, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,05,11,00,00), LengthInHours=3, TextBox="Appointment 28"},
                new Appointment{ClientID=20, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,05,10,15,00,00), LengthInHours=4, TextBox="Appointment 29"},
                new Appointment{ClientID=28, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,15,10,00,00), LengthInHours=2, TextBox="Appointment 30"},
                new Appointment{ClientID=31, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,20,13,00,00), LengthInHours=3, TextBox="Appointment 31"},
                new Appointment{ClientID=36, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,05,25,09,00,00), LengthInHours=1, TextBox="Appointment 32"},
                new Appointment{ClientID=39, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,30,14,30,00), LengthInHours=2, TextBox="Appointment 33"},
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,06,01,11,00,00), LengthInHours=3, TextBox="Appointment 34"},
                new Appointment{ClientID=16, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,06,01,15,00,00), LengthInHours=4, TextBox="Appointment 35"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,05,10,00,00), LengthInHours=2, TextBox="Appointment 36"},
                new Appointment{ClientID=37, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,10,13,00,00), LengthInHours=3, TextBox="Appointment 37"},
                new Appointment{ClientID=6, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,15,09,00,00), LengthInHours=1, TextBox="Appointment 38"},
                new Appointment{ClientID=22, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,20,14,30,00), LengthInHours=2, TextBox="Appointment 39"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,25,11,00,00), LengthInHours=3, TextBox="Appointment 40"},
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,01,15,00,00), LengthInHours=4, TextBox="Appointment 41"},
                new Appointment{ClientID=12, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,05,10,00,00), LengthInHours=2, TextBox="Appointment 42"},
                new Appointment{ClientID=17, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,10,13,00,00), LengthInHours=3, TextBox="Appointment 43"},
                new Appointment{ClientID=24, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,15,09,00,00), LengthInHours=1, TextBox="Appointment 44"},
                new Appointment{ClientID=27, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,20,14,30,00), LengthInHours=2, TextBox="Appointment 45"},
                new Appointment{ClientID=33, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,07,25,11,00,00), LengthInHours=3, TextBox="Appointment 46"},
                new Appointment{ClientID=35, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,01,15,00,00), LengthInHours=4, TextBox="Appointment 47"},
                new Appointment{ClientID=40, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,05,10,00,00), LengthInHours=2, TextBox="Appointment 48"},
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,10,13,00,00), LengthInHours=3, TextBox="Appointment 49"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,15,09,00,00), LengthInHours=1, TextBox="Appointment 50"},
                new Appointment{ClientID=19, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,20,14,30,00), LengthInHours=2, TextBox="Appointment 51"},
                new Appointment{ClientID=23, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,25,11,00,00), LengthInHours=3, TextBox="Appointment 52"},
                new Appointment{ClientID=29, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,08,30,15,00,00), LengthInHours=4, TextBox="Appointment 53"},
                new Appointment{ClientID=34, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,01,10,00,00), LengthInHours=2, TextBox="Appointment 54"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,05,13,00,00), LengthInHours=3, TextBox="Appointment 55"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,10,09,00,00), LengthInHours=1, TextBox="Appointment 56"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,15,14,30,00), LengthInHours=2, TextBox="Appointment 57"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,20,11,00,00), LengthInHours=3, TextBox="Appointment 58"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,25,15,00,00), LengthInHours=4, TextBox="Appointment 59"},
                new Appointment{ClientID=38, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,09,30,10,00,00), LengthInHours=2, TextBox="Appointment 60"},
                new Appointment{ClientID=6, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,01,09,00,00), LengthInHours=1, TextBox="Appointment 61"},
                new Appointment{ClientID=12, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,01,11,00,00), LengthInHours=2, TextBox="Appointment 62"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,01,14,00,00), LengthInHours=1, TextBox="Appointment 63"},
                new Appointment{ClientID=24, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,02,09,00,00), LengthInHours=2, TextBox="Appointment 64"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,02,12,00,00), LengthInHours=1, TextBox="Appointment 65"},
                new Appointment{ClientID=36, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,02,15,00,00), LengthInHours=2, TextBox="Appointment 66"},
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,03,09,00,00), LengthInHours=1, TextBox="Appointment 67"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,03,11,00,00), LengthInHours=2, TextBox="Appointment 68"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,03,14,00,00), LengthInHours=1, TextBox="Appointment 69"},
                new Appointment{ClientID=28, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,04,09,00,00), LengthInHours=2, TextBox="Appointment 70"},
                new Appointment{ClientID=35, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,04,12,00,00), LengthInHours=1, TextBox="Appointment 71"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,04,15,00,00), LengthInHours=2, TextBox="Appointment 72"},
                new Appointment{ClientID=16, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,05,09,00,00), LengthInHours=1, TextBox="Appointment 73"},
                new Appointment{ClientID=22, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,05,11,00,00), LengthInHours=2, TextBox="Appointment 74"},
                new Appointment{ClientID=29, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,05,14,00,00), LengthInHours=1, TextBox="Appointment 75"},
                new Appointment{ClientID=37, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,06,09,00,00), LengthInHours=2, TextBox="Appointment 76"},
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,06,12,00,00), LengthInHours=1, TextBox="Appointment 77"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,06,15,00,00), LengthInHours=2, TextBox="Appointment 78"},
                new Appointment{ClientID=20, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,07,09,00,00), LengthInHours=1, TextBox="Appointment 79"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,07,11,00,00), LengthInHours=2, TextBox="Appointment 80"},
                new Appointment{ClientID=33, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,07,14,00,00), LengthInHours=1, TextBox="Appointment 81"},
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,08,09,00,00), LengthInHours=2, TextBox="Appointment 82"},
                new Appointment{ClientID=15, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,08,12,00,00), LengthInHours=1, TextBox="Appointment 83"},
                new Appointment{ClientID=23, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,08,15,00,00), LengthInHours=2, TextBox="Appointment 84"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,09,09,00,00), LengthInHours=1, TextBox="Appointment 85"},
                new Appointment{ClientID=36, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,09,11,00,00), LengthInHours=2, TextBox="Appointment 86"},
                new Appointment{ClientID=10, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,09,14,00,00), LengthInHours=1, TextBox="Appointment 87"},
                new Appointment{ClientID=17, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,10,09,00,00), LengthInHours=2, TextBox="Appointment 88"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,10,12,00,00), LengthInHours=1, TextBox="Appointment 89"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,10,15,00,00), LengthInHours=2, TextBox="Appointment 90"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,11,09,00,00), LengthInHours=1, TextBox="Appointment 91"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,11,11,00,00), LengthInHours=2, TextBox="Appointment 92"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,11,14,00,00), LengthInHours=1, TextBox="Appointment 93"},
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,12,09,00,00), LengthInHours=2, TextBox="Appointment 94"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,12,12,00,00), LengthInHours=1, TextBox="Appointment 95"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,12,15,00,00), LengthInHours=2, TextBox="Appointment 96"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,13,09,00,00), LengthInHours=1, TextBox="Appointment 97"},
                new Appointment{ClientID=35, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,13,11,00,00), LengthInHours=2, TextBox="Appointment 98"},
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,13,14,00,00), LengthInHours=1, TextBox="Appointment 99"},
                new Appointment{ClientID=16, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,14,09,00,00), LengthInHours=2, TextBox="Appointment 100"},
                new Appointment{ClientID=24, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,14,12,00,00), LengthInHours=1, TextBox="Appointment 101"},
                new Appointment{ClientID=33, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,14,15,00,00), LengthInHours=2, TextBox="Appointment 102"},
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,15,09,00,00), LengthInHours=1, TextBox="Appointment 103"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,15,11,00,00), LengthInHours=2, TextBox="Appointment 104"},
                new Appointment{ClientID=20, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,15,14,00,00), LengthInHours=1, TextBox="Appointment 105"},
                new Appointment{ClientID=28, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,16,09,00,00), LengthInHours=2, TextBox="Appointment 106"},
                new Appointment{ClientID=37, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,16,12,00,00), LengthInHours=1, TextBox="Appointment 107"},
                new Appointment{ClientID=10, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,16,15,00,00), LengthInHours=2, TextBox="Appointment 108"},
                new Appointment{ClientID=15, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,17,09,00,00), LengthInHours=1, TextBox="Appointment 109"},
                new Appointment{ClientID=22, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,17,11,00,00), LengthInHours=2, TextBox="Appointment 110"},
                new Appointment{ClientID=29, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,17,14,00,00), LengthInHours=1, TextBox="Appointment 111"},
                new Appointment{ClientID=6, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,18,09,00,00), LengthInHours=2, TextBox="Appointment 112"},
                new Appointment{ClientID=11, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,18,12,00,00), LengthInHours=1, TextBox="Appointment 113"},
                new Appointment{ClientID=19, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,18,15,00,00), LengthInHours=2, TextBox="Appointment 114"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,19,09,00,00), LengthInHours=1, TextBox="Appointment 115"},
                new Appointment{ClientID=34, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,19,11,00,00), LengthInHours=2, TextBox="Appointment 116"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,19,14,00,00), LengthInHours=1, TextBox="Appointment 117"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,20,09,00,00), LengthInHours=2, TextBox="Appointment 118"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,20,12,00,00), LengthInHours=1, TextBox="Appointment 119"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,20,15,00,00), LengthInHours=2, TextBox="Appointment 120"},
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,21,09,00,00), LengthInHours=1, TextBox="Appointment 121"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,21,11,00,00), LengthInHours=2, TextBox="Appointment 122"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,21,14,00,00), LengthInHours=1, TextBox="Appointment 123"},
                new Appointment{ClientID=27, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,22,09,00,00), LengthInHours=2, TextBox="Appointment 124"},
                new Appointment{ClientID=36, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,22,12,00,00), LengthInHours=1, TextBox="Appointment 125"},
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,22,15,00,00), LengthInHours=2, TextBox="Appointment 126"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,23,09,00,00), LengthInHours=1, TextBox="Appointment 127"},
                new Appointment{ClientID=20, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,23,11,00,00), LengthInHours=2, TextBox="Appointment 128"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,23,14,00,00), LengthInHours=1, TextBox="Appointment 129"},
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,24,09,00,00), LengthInHours=2, TextBox="Appointment 130"},
                new Appointment{ClientID=15, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,24,12,00,00), LengthInHours=1, TextBox="Appointment 131"},
                new Appointment{ClientID=23, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,24,15,00,00), LengthInHours=2, TextBox="Appointment 132"},
                new Appointment{ClientID=31, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,25,09,00,00), LengthInHours=1, TextBox="Appointment 133"},
                new Appointment{ClientID=38, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,25,11,00,00), LengthInHours=2, TextBox="Appointment 134"},
                new Appointment{ClientID=11, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,25,14,00,00), LengthInHours=1, TextBox="Appointment 135"},
                new Appointment{ClientID=17, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,26,09,00,00), LengthInHours=2, TextBox="Appointment 136"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,26,12,00,00), LengthInHours=1, TextBox="Appointment 137"},
                new Appointment{ClientID=34, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,26,15,00,00), LengthInHours=2, TextBox="Appointment 138"},
                new Appointment{ClientID=6, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,27,09,00,00), LengthInHours=1, TextBox="Appointment 139"},
                new Appointment{ClientID=22, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,27,11,00,00), LengthInHours=2, TextBox="Appointment 140"},
                new Appointment{ClientID=33, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,27,14,00,00), LengthInHours=1, TextBox="Appointment 141"},
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,28,09,00,00), LengthInHours=2, TextBox="Appointment 142"},
                new Appointment{ClientID=19, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,28,12,00,00), LengthInHours=1, TextBox="Appointment 143"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,28,15,00,00), LengthInHours=2, TextBox="Appointment 144"},
                new Appointment{ClientID=12, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,29,09,00,00), LengthInHours=1, TextBox="Appointment 145"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,29,11,00,00), LengthInHours=2, TextBox="Appointment 146"},
                new Appointment{ClientID=27, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,29,14,00,00), LengthInHours=1, TextBox="Appointment 147"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,30,09,00,00), LengthInHours=2, TextBox="Appointment 148"},
                new Appointment{ClientID=39, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,30,12,00,00), LengthInHours=1, TextBox="Appointment 149"},
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,06,30,15,00,00), LengthInHours=2, TextBox="Appointment 150"},
                new Appointment{ClientID=8, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,04,09,00,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=11, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,09,14,00,00), LengthInHours=1, TextBox="Appointment 2"},
                new Appointment{ClientID=17, WorkerID=2, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,01,12,11,00,00), LengthInHours=2, TextBox="Appointment 3"},
                new Appointment{ClientID=21, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,18,15,00,00), LengthInHours=3, TextBox="Appointment 4"},
                new Appointment{ClientID=29, WorkerID=2, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,01,24,10,00,00), LengthInHours=1, TextBox="Appointment 5"},
                new Appointment{ClientID=34, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,28,13,00,00), LengthInHours=2, TextBox="Appointment 6"},
                new Appointment{ClientID=5, WorkerID=2, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,02,03,09,00,00), LengthInHours=1, TextBox="Appointment 7"},
                new Appointment{ClientID=13, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,07,11,00,00), LengthInHours=3, TextBox="Appointment 8"},
                new Appointment{ClientID=19, WorkerID=2, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,02,11,15,00,00), LengthInHours=2, TextBox="Appointment 9"},
                new Appointment{ClientID=27, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,17,10,00,00), LengthInHours=4, TextBox="Appointment 10"},
                new Appointment{ClientID=32, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,23,14,00,00), LengthInHours=1, TextBox="Appointment 11"},
                new Appointment{ClientID=37, WorkerID=2, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,02,27,09,00,00), LengthInHours=2, TextBox="Appointment 12"},
                new Appointment{ClientID=6, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,05,13,00,00), LengthInHours=1, TextBox="Appointment 13"},
                new Appointment{ClientID=14, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,11,11,00,00), LengthInHours=3, TextBox="Appointment 14"},
                new Appointment{ClientID=22, WorkerID=2, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,03,15,10,00,00), LengthInHours=2, TextBox="Appointment 15"},
                new Appointment{ClientID=30, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,21,14,00,00), LengthInHours=4, TextBox="Appointment 16"},
                new Appointment{ClientID=35, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,27,09,00,00), LengthInHours=1, TextBox="Appointment 17"},
                new Appointment{ClientID=7, WorkerID=2, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,04,03,11,00,00), LengthInHours=2, TextBox="Appointment 18"},
                new Appointment{ClientID=15, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,09,15,00,00), LengthInHours=3, TextBox="Appointment 19"},
                new Appointment{ClientID=23, WorkerID=2, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,04,13,10,00,00), LengthInHours=4, TextBox="Appointment 20"},
                new Appointment{ClientID=28, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,19,14,00,00), LengthInHours=1, TextBox="Appointment 21"},
                new Appointment{ClientID=36, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,25,09,00,00), LengthInHours=2, TextBox="Appointment 22"},
                new Appointment{ClientID=9, WorkerID=2, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,04,30,11,00,00), LengthInHours=3, TextBox="Appointment 23"},
                new Appointment{ClientID=18, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,05,15,00,00), LengthInHours=1, TextBox="Appointment 24"},
                new Appointment{ClientID=26, WorkerID=2, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,10,10,00,00), LengthInHours=2, TextBox="Appointment 25"},
                new Appointment{ClientID=33, WorkerID=2, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,05,14,14,00,00), LengthInHours=4, TextBox="Appointment 26"},
                new Appointment{ClientID=10, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,05,11,00,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=12, WorkerID=3, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,01,10,09,00,00), LengthInHours=1, TextBox="Appointment 2"},
                new Appointment{ClientID=20, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,14,13,00,00), LengthInHours=3, TextBox="Appointment 3"},
                new Appointment{ClientID=24, WorkerID=3, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,01,19,10,00,00), LengthInHours=2, TextBox="Appointment 4"},
                new Appointment{ClientID=31, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,23,15,00,00), LengthInHours=4, TextBox="Appointment 5"},
                new Appointment{ClientID=39, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,01,27,11,00,00), LengthInHours=1, TextBox="Appointment 6"},
                new Appointment{ClientID=6, WorkerID=3, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,02,02,09,00,00), LengthInHours=2, TextBox="Appointment 7"},
                new Appointment{ClientID=16, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,08,14,00,00), LengthInHours=3, TextBox="Appointment 8"},
                new Appointment{ClientID=21, WorkerID=3, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,02,13,10,00,00), LengthInHours=1, TextBox="Appointment 9"},
                new Appointment{ClientID=29, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,19,15,00,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=36, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,02,25,09,00,00), LengthInHours=3, TextBox="Appointment 11"},
                new Appointment{ClientID=8, WorkerID=3, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,03,03,13,00,00), LengthInHours=1, TextBox="Appointment 12"},
                new Appointment{ClientID=14, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,09,11,00,00), LengthInHours=2, TextBox="Appointment 13"},
                new Appointment{ClientID=25, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,15,09,00,00), LengthInHours=3, TextBox="Appointment 14"},
                new Appointment{ClientID=32, WorkerID=3, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,03,21,14,00,00), LengthInHours=1, TextBox="Appointment 15"},
                new Appointment{ClientID=5, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,03,27,10,00,00), LengthInHours=2, TextBox="Appointment 16"},
                new Appointment{ClientID=17, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,02,15,00,00), LengthInHours=4, TextBox="Appointment 17"},
                new Appointment{ClientID=22, WorkerID=3, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,04,08,09,00,00), LengthInHours=1, TextBox="Appointment 18"},
                new Appointment{ClientID=27, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,14,13,00,00), LengthInHours=2, TextBox="Appointment 19"},
                new Appointment{ClientID=33, WorkerID=3, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,04,20,11,00,00), LengthInHours=3, TextBox="Appointment 20"},
                new Appointment{ClientID=7, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,04,26,09,00,00), LengthInHours=1, TextBox="Appointment 21"},
                new Appointment{ClientID=15, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,02,14,00,00), LengthInHours=4, TextBox="Appointment 22"},
                new Appointment{ClientID=23, WorkerID=3, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,05,06,10,00,00), LengthInHours=1, TextBox="Appointment 23"},
                new Appointment{ClientID=28, WorkerID=3, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,12,15,00,00), LengthInHours=2, TextBox="Appointment 24"},
                new Appointment{ClientID=5, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,15,10,00,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=10, WorkerID=4, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,05,18,13,00,00), LengthInHours=1, TextBox="Appointment 2"},
                new Appointment{ClientID=14, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,20,09,00,00), LengthInHours=3, TextBox="Appointment 3"},
                new Appointment{ClientID=20, WorkerID=4, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,05,25,15,00,00), LengthInHours=2, TextBox="Appointment 4"},
                new Appointment{ClientID=28, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,05,28,11,00,00), LengthInHours=4, TextBox="Appointment 5"},
                new Appointment{ClientID=35, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,06,02,10,00,00), LengthInHours=1, TextBox="Appointment 6"},
                new Appointment{ClientID=7, WorkerID=4, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,06,05,13,00,00), LengthInHours=2, TextBox="Appointment 7"},
                new Appointment{ClientID=12, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,06,10,09,00,00), LengthInHours=3, TextBox="Appointment 8"},
                new Appointment{ClientID=17, WorkerID=4, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,06,15,15,00,00), LengthInHours=1, TextBox="Appointment 9"},
                new Appointment{ClientID=24, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,06,20,10,00,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=30, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,06,25,13,00,00), LengthInHours=4, TextBox="Appointment 11"},
                new Appointment{ClientID=37, WorkerID=4, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,06,28,09,00,00), LengthInHours=1, TextBox="Appointment 12"},
                new Appointment{ClientID=6, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,07,03,11,00,00), LengthInHours=2, TextBox="Appointment 13"},
                new Appointment{ClientID=15, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,07,08,15,00,00), LengthInHours=3, TextBox="Appointment 14"},
                new Appointment{ClientID=22, WorkerID=4, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,07,13,10,00,00), LengthInHours=1, TextBox="Appointment 15"},
                new Appointment{ClientID=27, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,07,18,14,00,00), LengthInHours=2, TextBox="Appointment 16"},
                new Appointment{ClientID=33, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,07,22,09,00,00), LengthInHours=4, TextBox="Appointment 17"},
                new Appointment{ClientID=9, WorkerID=4, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,07,27,13,00,00), LengthInHours=1, TextBox="Appointment 18"},
                new Appointment{ClientID=19, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,08,01,11,00,00), LengthInHours=2, TextBox="Appointment 19"},
                new Appointment{ClientID=26, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,08,06,15,00,00), LengthInHours=3, TextBox="Appointment 20"},
                new Appointment{ClientID=31, WorkerID=4, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,08,11,10,00,00), LengthInHours=1, TextBox="Appointment 21"},
                new Appointment{ClientID=38, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,08,16,14,00,00), LengthInHours=2, TextBox="Appointment 22"},
                new Appointment{ClientID=8, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,08,21,09,00,00), LengthInHours=4, TextBox="Appointment 23"},
                new Appointment{ClientID=13, WorkerID=4, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,08,25,13,00,00), LengthInHours=1, TextBox="Appointment 24"},
                new Appointment{ClientID=16, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,08,30,11,00,00), LengthInHours=2, TextBox="Appointment 25"},
                new Appointment{ClientID=23, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,09,03,15,00,00), LengthInHours=3, TextBox="Appointment 26"},
                new Appointment{ClientID=29, WorkerID=4, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,09,08,10,00,00), LengthInHours=1, TextBox="Appointment 27"},
                new Appointment{ClientID=34, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,09,13,14,00,00), LengthInHours=2, TextBox="Appointment 28"},
                new Appointment{ClientID=40, WorkerID=4, Status=Status.Done, AppointmentDateTime=new DateTime(2024,09,18,09,00,00), LengthInHours=4, TextBox="Appointment 29"},
                // 2021
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2021,03,01,10,00,00), LengthInHours=1, TextBox="Appointment 151"},
                new Appointment{ClientID=14, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2021,06,15,14,00,00), LengthInHours=2, TextBox="Appointment 152"},
                new Appointment{ClientID=21, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2021,09,10,09,00,00), LengthInHours=3, TextBox="Appointment 153"},
                new Appointment{ClientID=28, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2021,12,05,13,00,00), LengthInHours=1, TextBox="Appointment 154"},

                // 2022
                new Appointment{ClientID=5, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2022,01,20,10,00,00), LengthInHours=2, TextBox="Appointment 155"},
                new Appointment{ClientID=11, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2022,04,15,12,00,00), LengthInHours=1, TextBox="Appointment 156"},
                new Appointment{ClientID=19, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2022,07,10,14,00,00), LengthInHours=3, TextBox="Appointment 157"},
                new Appointment{ClientID=26, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2022,10,05,09,00,00), LengthInHours=2, TextBox="Appointment 158"},

                // 2023
                new Appointment{ClientID=8, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2023,02,18,11,00,00), LengthInHours=1, TextBox="Appointment 159"},
                new Appointment{ClientID=16, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2023,05,22,13,00,00), LengthInHours=2, TextBox="Appointment 160"},
                new Appointment{ClientID=23, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2023,08,17,15,00,00), LengthInHours=3, TextBox="Appointment 161"},
                new Appointment{ClientID=30, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2023,11,12,09,00,00), LengthInHours=2, TextBox="Appointment 162"},

                // 2024 (additional to existing list)
                new Appointment{ClientID=7, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,01,07,09,00,00), LengthInHours=2, TextBox="Appointment 163"},
                new Appointment{ClientID=13, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,02,03,11,00,00), LengthInHours=1, TextBox="Appointment 164"},
                new Appointment{ClientID=20, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,03,12,14,00,00), LengthInHours=2, TextBox="Appointment 165"},
                new Appointment{ClientID=27, WorkerID=1, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,04,05,15,00,00), LengthInHours=1, TextBox="Appointment 166"},

                // 2025
                new Appointment{ClientID=9, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2025,02,14,10,00,00), LengthInHours=2, TextBox="Appointment 167"},
                new Appointment{ClientID=18, WorkerID=1, Status=Status.Canceled, AppointmentDateTime=new DateTime(2025,05,25,12,00,00), LengthInHours=1, TextBox="Appointment 168"},
                new Appointment{ClientID=25, WorkerID=1, Status=Status.Done, AppointmentDateTime=new DateTime(2025,08,20,14,00,00), LengthInHours=3, TextBox="Appointment 169"},
                new Appointment{ClientID=32, WorkerID=1, Status=Status.NoShow, AppointmentDateTime=new DateTime(2025,11,15,09,00,00), LengthInHours=2, TextBox="Appointment 170"}

            };
            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();


            {/*
                var appointments = new List<Appointment>
            {
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,11,9,43,00), LengthInHours=2, TextBox="First"},
                new Appointment{ClientID=2, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,12,10,15,00), LengthInHours=1, TextBox="Second"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2020,3,12,9,43,00), LengthInHours=1, TextBox="Third"},
                new Appointment{ClientID=3, WorkerID=9, Status=Status.NoShow, AppointmentDateTime=new DateTime(2020,3,12,14,41,00), LengthInHours=3},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,9,43,00), LengthInHours=2, TextBox="Fifth"},
                new Appointment{ClientID=4, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,10,43,00), LengthInHours=2},
                new Appointment{ClientID=5, WorkerID=10, Status=Status.Canceled, AppointmentDateTime=new DateTime(2020,3,13,11,43,00), LengthInHours=1, TextBox="testy 7"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,13,12,43,00), LengthInHours=1},
                new Appointment{ClientID=6, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,14,9,43,00), LengthInHours=4},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,3,15,9,43,00), LengthInHours=1, TextBox="10 it is"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,3,16,9,43,00), LengthInHours=3},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,3,17,9,43,00), LengthInHours=2},
                new Appointment{ClientID=4, WorkerID=10, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,3,17,9,43,00), LengthInHours=5, TextBox="wordswordswords"},//AI GENERATED from here on
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,5,9,30,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,5,12,00,00), LengthInHours=3, TextBox="Appointment 2"},
                new Appointment{ClientID=3, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,6,10,15,00), LengthInHours=1, TextBox="Appointment 3"},
                new Appointment{ClientID=4, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,6,14,45,00), LengthInHours=4, TextBox="Appointment 4"},
                new Appointment{ClientID=5, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,7,11,30,00), LengthInHours=2, TextBox="Appointment 5"},
                new Appointment{ClientID=6, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,7,13,00,00), LengthInHours=3, TextBox="Appointment 6"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,10,30,00), LengthInHours=1, TextBox="Appointment 7"},
                new Appointment{ClientID=2, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,12,45,00), LengthInHours=5, TextBox="Appointment 8"},
                new Appointment{ClientID=3, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,9,00,00), LengthInHours=3, TextBox="Appointment 9"},
                new Appointment{ClientID=4, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,10,10,15,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=5, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,10,14,00,00), LengthInHours=3, TextBox="Appointment 11"},
                new Appointment{ClientID=6, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,11,9,30,00), LengthInHours=2, TextBox="Appointment 12"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,11,12,15,00), LengthInHours=1, TextBox="Appointment 13"},
                new Appointment{ClientID=2, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 14"},
                new Appointment{ClientID=3, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 15"},
                new Appointment{ClientID=4, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 16"},
                new Appointment{ClientID=5, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,10,30,00), LengthInHours=1, TextBox="Appointment 17"},
                new Appointment{ClientID=6, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,12,45,00), LengthInHours=5, TextBox="Appointment 18"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,9,00,00), LengthInHours=3, TextBox="Appointment 19"},
                new Appointment{ClientID=3, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,7,14,00,00), LengthInHours=2, TextBox="Appointment 21"},
                new Appointment{ClientID=4, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,8,9,30,00), LengthInHours=3, TextBox="Appointment 22"},
                new Appointment{ClientID=5, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,8,12,15,00), LengthInHours=1, TextBox="Appointment 23"},
                new Appointment{ClientID=6, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,15,45,00), LengthInHours=4, TextBox="Appointment 24"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,10,10,30,00), LengthInHours=2, TextBox="Appointment 25"},
                new Appointment{ClientID=2, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 26"},
                new Appointment{ClientID=3, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 27"},
                new Appointment{ClientID=4, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 28"},
                new Appointment{ClientID=5, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 29"},
                new Appointment{ClientID=6, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,8,10,15,00), LengthInHours=2, TextBox="Appointment 30"},
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,14,00,00), LengthInHours=2, TextBox="Appointment 31"},
                new Appointment{ClientID=2, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=3, TextBox="Appointment 32"},
                new Appointment{ClientID=3, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,10,12,15,00), LengthInHours=1, TextBox="Appointment 33"},
                new Appointment{ClientID=4, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 34"},
                new Appointment{ClientID=5, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 35"},
                new Appointment{ClientID=6, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 36"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 37"},
                new Appointment{ClientID=2, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 38"},
                new Appointment{ClientID=3, WorkerID=11, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 39"},
                new Appointment{ClientID=4, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,8,10,15,00), LengthInHours=2, TextBox="Appointment 40"},
                new Appointment{ClientID=5, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,9,14,00,00), LengthInHours=2, TextBox="Appointment 41"},
                new Appointment{ClientID=6, WorkerID=9, Status=Status.Canceled, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=3, TextBox="Appointment 42"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.NoShow, AppointmentDateTime=new DateTime(2024,5,10,12,15,00), LengthInHours=1, TextBox="Appointment 43"},
                new Appointment{ClientID=2, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,15,45,00), LengthInHours=4, TextBox="Appointment 44"},
                new Appointment{ClientID=3, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=2, TextBox="Appointment 45"},
                new Appointment{ClientID=4, WorkerID=8, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,13,00,00), LengthInHours=3, TextBox="Appointment 46"},
                new Appointment{ClientID=5, WorkerID=9, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 47"},
                new Appointment{ClientID=6, WorkerID=10, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 48"},
                new Appointment{ClientID=2, WorkerID=12, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,11,10,15,00), LengthInHours=2, TextBox="Appointment 20"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,10,00,00), LengthInHours=2, TextBox="Appointment 49"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,14,00,00), LengthInHours=3, TextBox="Appointment 50"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,10,30,00), LengthInHours=1, TextBox="Appointment 51"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,12,45,00), LengthInHours=5, TextBox="Appointment 52"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,9,00,00), LengthInHours=3, TextBox="Appointment 53"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,7,14,15,00), LengthInHours=2, TextBox="Appointment 54"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,11,30,00), LengthInHours=1, TextBox="Appointment 55"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,13,45,00), LengthInHours=4, TextBox="Appointment 56"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,9,15,00), LengthInHours=2, TextBox="Appointment 57"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,9,13,30,00), LengthInHours=3, TextBox="Appointment 58"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,10,45,00), LengthInHours=1, TextBox="Appointment 59"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,12,00,00), LengthInHours=2, TextBox="Appointment 60"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,10,30,00), LengthInHours=3, TextBox="Appointment 61"},
                new Appointment{ClientID=2, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,14,45,00), LengthInHours=2, TextBox="Appointment 62"},
                new Appointment{ClientID=3, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,11,16,15,00), LengthInHours=4, TextBox="Appointment 63"},
                new Appointment{ClientID=4, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,5,12,00,00), LengthInHours=2, TextBox="New Appointment 1"},
                new Appointment{ClientID=5, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,6,15,00,00), LengthInHours=2, TextBox="New Appointment 2"},
                new Appointment{ClientID=6, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,8,14,30,00), LengthInHours=3, TextBox="New Appointment 3"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 1"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,2,20,11,0,00), LengthInHours=1, TextBox="Appointment 2"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2020,3,18,14,0,00), LengthInHours=3, TextBox="Appointment 3"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,4,22,10,0,00), LengthInHours=2, TextBox="Appointment 4"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,5,19,15,0,00), LengthInHours=2, TextBox="Appointment 5"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2020,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 6"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 7"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 8"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2020,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 9"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2020,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 10"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2020,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 11"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2020,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 12"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2021,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 13"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2021,2,18,11,0,00), LengthInHours=1, TextBox="Appointment 14"},
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2021,3,22,14,0,00), LengthInHours=3, TextBox="Appointment 15"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2021,4,19,10,0,00), LengthInHours=2, TextBox="Appointment 16"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2021,5,17,15,0,00), LengthInHours=2, TextBox="Appointment 17"},
                new Appointment{ClientID=1, WorkerID=13, Status=Status.Done, AppointmentDateTime=new DateTime(2021,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 18"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2021,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 19"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2021,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 20"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2021,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 21"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2021,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 22"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2021,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 23"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2021,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 24"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2022,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 25"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2022,2,18,11,0,00), LengthInHours=1, TextBox="Appointment 26"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2022,3,22,14,0,00), LengthInHours=3, TextBox="Appointment 27"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2022,4,19,10,0,00), LengthInHours=2, TextBox="Appointment 28"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2022,5,17,15,0,00), LengthInHours=2, TextBox="Appointment 29"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2022,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 30"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2022,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 31"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2022,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 32"},
                new Appointment{ClientID=1, WorkerID=13, Status=Status.Done, AppointmentDateTime=new DateTime(2022,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 33"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2022,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 34"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2022,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 35"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2022,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 36"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2023,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 37"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2023,2,18,11,0,00), LengthInHours=1, TextBox="Appointment 38"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2023,3,22,14,0,00), LengthInHours=3, TextBox="Appointment 39"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2023,4,19,10,0,00), LengthInHours=2, TextBox="Appointment 40"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2023,5,17,15,0,00), LengthInHours=2, TextBox="Appointment 41"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2023,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 42"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2023,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 43"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2023,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 44"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2023,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 45"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2023,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 46"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2023,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 47"},
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2023,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 48"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 49"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,2,18,11,0,00), LengthInHours=1, TextBox="Appointment 50"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2024,3,22,14,0,00), LengthInHours=3, TextBox="Appointment 51"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,4,19,10,0,00), LengthInHours=2, TextBox="Appointment 52"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,5,17,15,0,00), LengthInHours=2, TextBox="Appointment 53"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2024,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 54"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 55"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 56"},
                new Appointment{ClientID=1, WorkerID=10, Status=Status.Done, AppointmentDateTime=new DateTime(2024,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 57"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 58"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2024,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 59"},
                new Appointment{ClientID=1, WorkerID=9, Status=Status.Done, AppointmentDateTime=new DateTime(2024,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 60"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2025,1,15,9,0,00), LengthInHours=2, TextBox="Appointment 61"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2025,2,18,11,0,00), LengthInHours=1, TextBox="Appointment 62"},
                new Appointment{ClientID=1, WorkerID=8, Status=Status.Done, AppointmentDateTime=new DateTime(2025,3,22,14,0,00), LengthInHours=3, TextBox="Appointment 63"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2025,4,19,10,0,00), LengthInHours=2, TextBox="Appointment 64"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2025,5,17,15,0,00), LengthInHours=2, TextBox="Appointment 65"},
                new Appointment{ClientID=1, WorkerID=13, Status=Status.Done, AppointmentDateTime=new DateTime(2025,6,21,13,0,00), LengthInHours=1, TextBox="Appointment 66"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2025,7,23,16,0,00), LengthInHours=2, TextBox="Appointment 67"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2025,8,17,11,30,00), LengthInHours=1, TextBox="Appointment 68"},
                new Appointment{ClientID=1, WorkerID=12, Status=Status.Done, AppointmentDateTime=new DateTime(2025,9,14,14,0,00), LengthInHours=3, TextBox="Appointment 69"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2025,10,19,10,30,00), LengthInHours=2, TextBox="Appointment 70"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Confirmed, AppointmentDateTime=new DateTime(2025,11,18,12,0,00), LengthInHours=1, TextBox="Appointment 71"},
                new Appointment{ClientID=1, WorkerID=11, Status=Status.Done, AppointmentDateTime=new DateTime(2025,12,21,13,30,00), LengthInHours=2, TextBox="Appointment 72"},
                new Appointment{ClientID=1, WorkerID=14, Status=Status.Pending, AppointmentDateTime=new DateTime(2024,5,10,9,30,00), LengthInHours=2, TextBox="New Appointment 4"}



            };
                appointments.ForEach(s => context.Appointments.Add(s));
                context.SaveChanges();
            */}
        

            var users = new List<User>
            {
                new User{IsActive=true,Username="Admin",Password=BCrypt.Net.BCrypt.HashPassword("Admin")},
                new User{IsActive=true,Username="Dentist",Password=BCrypt.Net.BCrypt.HashPassword("DentistPassword")},
                new User{IsActive=true,Username="Assistant",Password=BCrypt.Net.BCrypt.HashPassword("AssistantPassword")},
                new User{IsActive=true,Username="Secretary",Password=BCrypt.Net.BCrypt.HashPassword("Secretary")},
                new User{IsActive=true,Username="Shinanit",Password=BCrypt.Net.BCrypt.HashPassword("ShinanitPassword")},
                new User{IsActive=false,Username="DentistOld",Password=BCrypt.Net.BCrypt.HashPassword("DentistOldPassword")},
                new User{IsActive=false,Username="ShinanitOld",Password=BCrypt.Net.BCrypt.HashPassword("ShinanitOldPassword")}
                //new User{IsActive=true,Username="RoleUserControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleUserControl")},
                //new User{IsActive=true,Username="RoleAppointmentControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleAppointmentControl")},
               // new User{IsActive=true,Username="RoleAppointmentEnd",Password=BCrypt.Net.BCrypt.HashPassword("RoleAppointmentEnd")},
                //new User{IsActive=true,Username="RoleClientControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleClientControl")},
                //new User{IsActive=true,Username="RoleWorkerControl",Password=BCrypt.Net.BCrypt.HashPassword("RoleWorkerControl")}

            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{RoleName="Admin"},   //access to everything
                new Role{RoleName="UserControl"},  //access to adding users, giving/taking roles and setting users inactive
                new Role{RoleName="AppointmentControl"}, //full control over appointments
                new Role{RoleName="AppointmentEnd"},    //can edit appointment after it happened, can comment on it and change the status
                new Role{RoleName="ClientControl"},     //can add and edit clients 
                new Role{RoleName="WorkerControl"}  //can add and edit workers
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var userRoleMaps = new List<UserRoleMap>
            {
                new UserRoleMap{UserID=1,RoleID=1}, //admin all roles
                new UserRoleMap{UserID=1,RoleID=2},
                new UserRoleMap{UserID=1,RoleID=3},
                new UserRoleMap{UserID=1,RoleID=4},
                new UserRoleMap{UserID=1,RoleID=5},
                new UserRoleMap{UserID=1,RoleID=6},
                new UserRoleMap{UserID=2,RoleID=2}, //dentist all roles except for Admin role
                new UserRoleMap{UserID=2,RoleID=3},
                new UserRoleMap{UserID=2,RoleID=4},
                new UserRoleMap{UserID=2,RoleID=5},
                new UserRoleMap{UserID=2,RoleID=6},
                new UserRoleMap{UserID=4,RoleID=3}, //secretary clients and appointment roles
                new UserRoleMap{UserID=4,RoleID=5},
                new UserRoleMap{UserID=5,RoleID=4} //shinanit appointmentEnd role
                //new UserRoleMap{UserID=6,RoleID=2},
                //new UserRoleMap{UserID=7,RoleID=3},
                //new UserRoleMap{UserID=8,RoleID=4},
                //new UserRoleMap{UserID=9,RoleID=5},
                //new UserRoleMap{UserID=10,RoleID=6}

            };
            userRoleMaps.ForEach(s => context.UserRoleMaps.Add(s));
            context.SaveChanges();
        }
    }
}