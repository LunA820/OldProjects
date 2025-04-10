using MagicVilla_VillaAPI.Models.Dto;


namespace MagicVilla_VillaAPI.FakeDatabase
{
    /// <summary>
    ///     We use this as a fake Database such that we do not need to deal with DB now.
    /// </summary>
    public static class FakeDB
    {
        /// <summary>
        ///     Pretend to return a list of Data from the database.
        /// </summary>
        public static List<VillaDTO> villaList = new List<VillaDTO>()
        {
            new VillaDTO { Id = 1, Name="Luna" },
            new VillaDTO { Id = 2, Name="Sophia"}
        };
    }
}
