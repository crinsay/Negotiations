﻿namespace Negotiations.Domain.Constants;

public static class NegotiationStatuses
{
    public const string Pending = "Pending";
    public const string Accepted = "Accepted";
    public const string Declined = "Declined";
    public const string Cancelled = "Cancelled";

    public static readonly string[] AllowedEmployeeStatuses = [Accepted, Declined];
}
