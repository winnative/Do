using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Emtudio.Systems.Entities
{
    public class ReminderModel : INotifyPropertyChanged
    {
        private int id;
        private string description;
        private DateTime time;
        private bool isImportant;
        private int daysBefore;
        public ReminderModel(Reminder reminder)
        {
            id = reminder.ID;
            description = reminder.Description;
            time = reminder.Time;
            isImportant = reminder.IsImportant;
            daysBefore = reminder.DaysBefore;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public int DaysBefore
        {
            get
            {
                return daysBefore;
            }
            set
            {
                daysBefore = value;
                OnPropertyChanged("DaysBefore");
            }
        }

        public bool IsImportant
        {
            get
            {
                return isImportant;
            }
            set
            {
                isImportant = value;
                OnPropertyChanged("IsImportant");
            }
        }
    }
}
