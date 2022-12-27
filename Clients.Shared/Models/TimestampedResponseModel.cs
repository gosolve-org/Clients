using System;
namespace GoSolve.Clients.Shared.Models;

/// <summary>
/// Abstract class with timestamp properties.
/// </summary>
public abstract class TimestampedResponse
{
    /// <summary>
    /// Date of creation.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date of last update.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
