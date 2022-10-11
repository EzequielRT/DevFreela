namespace DevFreela.API.Models
{
    public class CreateProjectModel
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void SetId(int id) => Id = id;
    }
}