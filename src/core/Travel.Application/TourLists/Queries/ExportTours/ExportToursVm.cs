namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class ExportToursVm
    {
        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public required byte[] Content {get; set;}
    }
}