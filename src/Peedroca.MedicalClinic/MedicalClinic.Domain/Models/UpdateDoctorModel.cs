﻿using Flunt.Notifications;
using Flunt.Validations;

namespace MedicalClinic.Domain.Models
{
    /// <summary>
    /// Modelo de atualização de médico
    /// </summary>
    public class UpdateDoctorModel : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id">Identificação</param>
        /// <param name="name">Nome</param>
        /// <param name="specialty">Especialidade</param>
        /// <param name="phone">Telefone</param>
        public UpdateDoctorModel(long id
            , string name
            , string specialty
            , string phone)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            Phone = phone;

            AddNotifications(new Contract()
                .IsGreaterThan(Id, 0, nameof(Id), "Identificação inválida")
                .IsNotNullOrEmpty(Name, nameof(Name), "O nome não pode estar em branco.")
                .HasMinLen(Name, 1, nameof(Name), "O nome deve ter mais de 1 caractér")
                .HasMaxLen(Name, 100, nameof(Name), "O nome não pode ter mais de 100 caracteres.")
                .IsNotNullOrEmpty(Specialty, nameof(Specialty), "A especialidade não pode estar em branco.")
                .HasMinLen(Specialty, 5, nameof(Specialty), "A especialidade deve ter mais de 5 caracteres")
                .HasMaxLen(Specialty, 70, nameof(Specialty), "A especialidade não pode ter mais de 70 caracteres.")
                .IsNotNullOrEmpty(Phone, nameof(Phone), "O telefone não pode estar em branco.")
                .HasMaxLen(Phone, 25, nameof(Phone), "O telefone não pode ter mais de 20 caracteres."));
        }

        /// <summary>
        /// Identificação
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Especialidade
        /// </summary>
        public string Specialty { get; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Phone { get; }
    }
}
