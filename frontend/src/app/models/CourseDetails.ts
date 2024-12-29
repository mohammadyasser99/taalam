export interface Lesson {
  id: number;
  title: string;
  duration?: string;
  content?: string;
  isCompleted: boolean;
  lessonNumber?: number;
}

export interface Quiz {
  id: number;
  title: string;
}

export interface Section {
  id: number;
  title: string;
  lessonsNo: number;
  sectionNumber: number;
  lessons: Lesson[];
  quizes: Quiz[];
}

export interface CourseCategory {
  id: number;
  name: string;
}

export interface Instructor {
  id: number;
  fName: string;
  lName: string;
  description?: string;
  profilePicture?:string
}

export interface StudentEnrollment {
  progressPercentage: number;
  completedLessons: number;
  enrollmentDate: string;
}

export interface Course {
  id: number;
  title: string;
  description?: string;
  coverPicture: string;
  price: number;
  rate?: number;
  creationDate: string;
  updatedDate?: string | null;
  sectionsNo: number;
  courseCategory: CourseCategory;
  sections: Section[];
  instructor: Instructor;
  studentEnrollment: StudentEnrollment; // Include the student enrollment details
}
