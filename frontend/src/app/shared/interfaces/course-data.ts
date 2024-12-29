export interface CourseData {
  userId:number,
  title: string;
  description: string;
  duration: string;
  courseCategory: string;
  coverPicture: string;
  price: number;
  sectionsNo: number;
  sections: Section[];
}

export interface IEnrolledCourse {
  id: number,
  title: string,
  instructorName:string,
  InstructorInfo:string,
  description: string,
  price: number,
  rate: number,
  progress:number,
  coverPicture: string,
  categoryName:string,
  duration: number
}

export interface Section {
  sectionTitle: string;
  numberOfLessons: number;
  lessons: Lesson[];
  // quizzes: Quiz[];
}

export interface Lesson {
  lessonTitle: string;
  lessonUrl: string;
}


export interface CourseDataForEditing {
  CourseId: number;
  userId: number;
  title: string;
  description: string;
  duration: string;
  courseCategory: string;
  coverPicture: string;
  price: number;
  sectionsNo: number;
  sections: SectionForEditing[];
}

export interface SectionForEditing {
  sectionId: number;
  sectionTitle: string;
  numberOfLessons: number;
  lessons: LessonForEditing[];
}

export interface LessonForEditing {
  lessonId: number;
  lessonTitle: string;
  lessonUrl: string;
}
