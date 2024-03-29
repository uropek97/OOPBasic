﻿using Lesson_8.Commands.Base;

namespace Lesson_8.Commands;

public class ListDrivesCommand : FMCommands
{
    public override string? Description => "Выводит список дисков на экран";
    private readonly IUserInterface _UserInterface;

    public ListDrivesCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    public override void Execute(string[] args)
    {
        var drives = DriveInfo.GetDrives();
        _UserInterface.WriteLine($"В файловой системе существует дисков: {drives.Length}");
        foreach (var drive in drives)
            _UserInterface.WriteLine($"----{drive.Name}");
    }
}
