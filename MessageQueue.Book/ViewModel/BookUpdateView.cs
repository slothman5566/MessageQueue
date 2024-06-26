﻿namespace MessageQueue.Book.ViewModel
{
    public class BookUpdateView
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
