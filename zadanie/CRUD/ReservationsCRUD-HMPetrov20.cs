using (var context = new LibraryContext())
{
    // CREATE
    var reservation = new Reservation { BookID = 1, MemberID = 1, ReservationDate = DateTime.Now };
    context.Reservations.Add(reservation);
    context.SaveChanges();

    // READ
    var reservations = context.Reservations.Include(r => r.Book).Include(r => r.Member).ToList();
    foreach (var res in reservations)
    {
        Console.WriteLine($"{res.ReservationID}: {res.Book.Title} reserved by {res.Member.Name}");
    }

    // UPDATE
    var reservationToUpdate = context.Reservations.FirstOrDefault(r => r.ReservationID == reservation.ReservationID);
    if (reservationToUpdate != null)
    {
        reservationToUpdate.ReservationDate = DateTime.Now.AddDays(1);
        context.SaveChanges();
    }

    // DELETE
    var reservationToDelete = context.Reservations.FirstOrDefault(r => r.ReservationID == reservation.ReservationID);
    if (reservationToDelete != null)
    {
        context.Reservations.Remove(reservationToDelete);
        context.SaveChanges();
    }
}
