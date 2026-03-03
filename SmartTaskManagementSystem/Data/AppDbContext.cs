using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartTaskManagementSystem.Models;

namespace SmartTaskManagementSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TaskItem> Tasks { get; set; }

    public virtual DbSet<TaskComment> TaskComments { get; set; }

    public virtual DbSet<TaskHistory> TaskHistories { get; set; }

    public virtual DbSet<TaskPriority> TaskPriorities { get; set; }

    public virtual DbSet<TaskStatusItem> TaskStatuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwTaskDashboard> VwTaskDashboards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF099E71E4B");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ProjectName).HasMaxLength(150);

            entity.HasOne(d => d.Team).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teamid");
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B1E1A36E66");

            entity.HasIndex(e => e.AssignedTo, "IX_Tasks_AssignedTo");

            entity.HasIndex(e => e.DueDate, "IX_Tasks_DueDate");

            entity.HasIndex(e => e.ProjectId, "IX_Tasks_ProjectId");

            entity.HasIndex(e => e.StatusId, "IX_Tasks_StatusId");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_assignedto");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_priority");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projectid");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status");
        });

        modelBuilder.Entity<TaskComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__TaskComm__C3B4DFCADD246459");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CommentedByNavigation).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.CommentedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_taskcomment_commentedby");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_taskcomment_task");
        });

        modelBuilder.Entity<TaskHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__TaskHist__4D7B4ABDB7F4A020");

            entity.ToTable("TaskHistory");

            entity.Property(e => e.ChangedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ChangedField).HasMaxLength(50);
            entity.Property(e => e.NewValue).HasMaxLength(200);
            entity.Property(e => e.OldValue).HasMaxLength(200);

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.TaskHistories)
                .HasForeignKey(d => d.ChangedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskHistory_User");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskHistories)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskHistory_Task");
        });

        modelBuilder.Entity<TaskPriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PK__TaskPrio__D0A3D0BED8CE8E17");

            entity.ToTable("TaskPriority");

            entity.Property(e => e.PriorityName).HasMaxLength(50);
        });

        modelBuilder.Entity<TaskStatusItem>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__TaskStat__C8EE206398475814");

            entity.ToTable("TaskStatus");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7998AAF48A7");

            entity.HasIndex(e => e.TeamName, "UQ__Teams__4E21CAAC3A75D85C").IsUnique();

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.TeamId }).HasName("PK__TeamMemb__96AB6235EADBDCDB");

            entity.Property(e => e.JoinedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_team");

            entity.HasOne(d => d.User).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C546E93DF");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F917D67C").IsUnique();

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTaskDashboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TaskDashboard");

            entity.Property(e => e.AssignedTo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assignedTo");
            entity.Property(e => e.Duedate).HasColumnName("duedate");
            entity.Property(e => e.Priorityname)
                .HasMaxLength(50)
                .HasColumnName("priorityname");
            entity.Property(e => e.StatusName).HasMaxLength(50);
            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
