namespace cwiczenia12.Exceptions;


public class ClientNotFoundException(string message) : Exception(message);

public class ClientAlreadyAssignedToTripException(string message) : Exception(message);

public class ClientAssignedToActiveTripsException(string message) : Exception(message);

public class TripNotFoundException(string message) : Exception(message);

public class TripNotAvailableException(string message) : Exception(message);