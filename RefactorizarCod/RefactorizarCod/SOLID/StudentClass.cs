namespace RefactorizarCod.SOLID
{
    public class StudentClass
    {
        public interface IStudentRepository
        {
            void Save(Student student);
            void Delete(Student student);
        }

        //Procesar pagos
        public interface IPaymentProcessor
        {
            bool ProcessPayment(Student student, Course course);
        }

        // Suscripcion cursos
        public interface ICourseSubscriptionService
        {
            void Subscribe(Student student, Course course);
        }

        // Correos
        public interface IEmailService
        {
            void SendConfirmationEmail(Student student, Course course);
        }
        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DoB { get; set; }
            public string Email { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }
        }

        public class StudentRepository : IStudentRepository
        {
            public void Save(Student student)
            {
                Console.WriteLine("Guardando estudiante en la DB...");
               //Guardar estudiante DB
            }

            public void Delete(Student student)
            {
                Console.WriteLine("Eliminando estudiante de la DB...");
                //Eliminar estudiante DB
            }
        }
        public class PaymentProcessor : IPaymentProcessor
        {
            public bool ProcessPayment(Student student, Course course)
            {
                Console.WriteLine("Procediendo con el pago...");
                return true; 
            }
        }

        //Envio de correos
        public class EmailService : IEmailService
        {
            public void SendConfirmationEmail(Student student, Course course)
            {
                Console.WriteLine($"Enviando confirmacion de email a  {student.Email}...");
            }
        }
        public class CourseSubscriptionService : ICourseSubscriptionService
        {
            private readonly IPaymentProcessor _paymentProcessor;
            private readonly IEmailService _emailService;

            public CourseSubscriptionService(IPaymentProcessor paymentProcessor, IEmailService emailService)
            {
                _paymentProcessor = paymentProcessor;
                _emailService = emailService;
            }

            public void Subscribe(Student student, Course course)
            {
                Console.WriteLine("Empezando el proceso de suscripcion...");

                // Validación según tipo de curso
                if (course.Type == "online")
                {
                    Console.WriteLine("Validando curso online...");
                }
                else if (course.Type == "live")
                {
                    Console.WriteLine("Validando el curso...");
                }

                // Procesar pago
                if (_paymentProcessor.ProcessPayment(student, course))
                {
                    // Guardar la suscripción 
                    Console.WriteLine("Guardando la descripcion del curso...");

                    // Enviar correo de confirmación
                    _emailService.SendConfirmationEmail(student, course);
                }

                Console.WriteLine("Suscripcion completada.");
            }
        }
        public class Course
        {
            public string Type { get; set; }
            public string Title { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                IStudentRepository studentRepository = new StudentRepository();
                IPaymentProcessor paymentProcessor = new PaymentProcessor();
                IEmailService emailService = new EmailService();
                ICourseSubscriptionService subscriptionService = new CourseSubscriptionService(paymentProcessor, emailService);

                Student student = new Student { StudentId = 1, FirstName = "Harold", LastName = "Morillo", Email = "hmorillopichardo@gmail.com" };
                Course course = new Course { Type = "online", Title = "C# Intermedio ITLA" };

                studentRepository.Save(student);

                subscriptionService.Subscribe(student, course);

                studentRepository.Delete(student);
            }
        }

    }
}
