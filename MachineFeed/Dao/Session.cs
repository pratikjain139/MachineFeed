namespace MachineFeed.Dao {
    public class Session {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }




        private String createdAt;

        public String CreatedAt {
            get { return createdAt; }
            set { createdAt = value; }
        }

        private String updatedAt;

        public String UpdatedAt {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        private String updatedBy;

        public String UpdatedBy {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        private String description;

        public String Description {
            get { return description; }
            set { description = value; }
        }


    }
}
