namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaDTO
    {
        /*
            We might want to record the created DateTime of the data, 
            but we don't want it to be explosed to the end users.
            We can create a DTO class for the original object.
         */
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
