// class to store the a static list of all reservations to a JSON file to act as a common repository to add and retrieve reservations.
using System.Text.Json;

public static class FinalReservationJSONRepository
{
    private static readonly string Reservations_JSON = "reservations.json";
    
    public static void addNewReservation(FinalReservationData reservationData)
    {
        if (File.Exists(Reservations_JSON) && new FileInfo(Reservations_JSON).Length > 0)
{
    try
    {
        List<FinalReservationData> reservationJsonContent = JsonSerializer.Deserialize<List<FinalReservationData>>(File.ReadAllText(Reservations_JSON))!;
        reservationData.reservationID = getReservations().Count + 1;
        reservationJsonContent.Add(reservationData);
        string reservationJson = JsonSerializer.Serialize(reservationJsonContent, new JsonSerializerOptions { WriteIndented = true });
        // write string back to file.
        File.WriteAllText(Reservations_JSON, reservationJson);
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by initializing a new list
        List<FinalReservationData> reservations = new List<FinalReservationData>();
        reservationData.reservationID = getReservations().Count + 1;
        reservations.Add(reservationData);
        string reservationJson = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Reservations_JSON, reservationJson);
    }
}
else
{
    List<FinalReservationData> reservations = new List<FinalReservationData>();
    reservationData.reservationID = getReservations().Count + 1;
    reservations.Add(reservationData);
    string reservationJson = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(Reservations_JSON, reservationJson);
}


    }

    public static List<FinalReservationData> getReservations()
    {
        if (File.Exists(Reservations_JSON) && new FileInfo(Reservations_JSON).Length > 0)
    {
    try
    {
        List<FinalReservationData> reservationsJsonContent = JsonSerializer.Deserialize<List<FinalReservationData>>(File.ReadAllText(Reservations_JSON))!;
        return reservationsJsonContent;
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by returning an empty list
        return new List<FinalReservationData>();
    }
}
else
{
    return new List<FinalReservationData>();
}



    }
}
