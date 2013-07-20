var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },

    introduce: function () {
        return this._super.introduce() + ", Grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },

    introduce: function () {
        return this._super.introduce() + ", Speciality: " + this.speciality;
    }
});

var Class = {
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },
    
    introduceParticipants: function(){
        var classTextRepresentation = "Class name: " + this.name + ", capacity: " + this.capacity;
        classTextRepresentation = classTextRepresentation + "\n";
        classTextRepresentation = classTextRepresentation + "Form Teacher: " + this.formTeacher.introduce();
        for (var i = 0, len = this.students.length; i < len; i++) {
            classTextRepresentation = classTextRepresentation + "\n" + this.students[i].introduce();
        }

        return classTextRepresentation;
    }
}


var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },

    introduceSchoolMembers: function () {
        var schoolTextRepresentation = "School name: " + this.name + ", Town: " + this.town;
        for (var i = 0, len = this.classes.length; i < len; i++) {
            schoolTextRepresentation = schoolTextRepresentation + "\n" + this.classes[i].introduceParticipants();
        }

        return schoolTextRepresentation;
    }
}

var studentIvan = Object.create(Student);
studentIvan.init("Ivan", "Hristov", 16, 10);

var studentBoryana = Object.create(Student);
studentBoryana.init("Boryana", "Ivanova", 16, 10);

var studentIvelina = Object.create(Student);
studentIvelina.init("Ivelina", "Popova", 15, 10);

var teacher = Object.create(Teacher);
teacher.init("Stoyan", "Petrov", 32, "Chemist");

var classSchool = Object.create(Class);
classSchool.init("Chemistry", 30, [studentBoryana, studentIvan, studentIvelina], teacher);
console.log(classSchool.introduceParticipants());

var school = Object.create(School);
school.init("SOU Ivan Vazov", "Plovdiv", [classSchool]);
console.log(school.introduceSchoolMembers());