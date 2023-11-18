namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.CommandNotifications;

public record ConnectionNotification(string Notification = "You are not connected to any file system") : Notification;