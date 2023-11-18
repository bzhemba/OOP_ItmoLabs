namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

public record CommandFormatNotification(string Notification = "Invalid command format") : Notification;