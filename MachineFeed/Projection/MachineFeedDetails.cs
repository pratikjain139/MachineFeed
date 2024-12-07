namespace MachineFeed.Projection {
    public class MachineFeedDetails {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private String feedType;

        public String FeedType {
            get { return feedType; }
            set { feedType = value; }
        }


        private String type;

        public String Type {
            get { return type; }
            set { type = value; }
        }

        private String model;

        public String Model {
            get { return model; }
            set { model = value; }
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

        private String image;

        public String Image {
            get { return image; }
            set { image = value; }
        }
    }
}
