export interface Rating {
  id: number;
  userId: number;
  courseId: number;
  value: number;
  description?: string;
}

export interface RatingDTO {
  courseId: number;
  value: number;
  description?: string;
}

export interface ReadCourseRatingDTO {
  id: number;
  description: string;
  value: number;
  student: {
    id: number;
    profilePicture?: string;
    name: string;
  };
}

export interface ReadCourseRatingByUserDTO {
  id: number;
  description: string;
  value: number;
  course: {
    id: number;
    title: string;
    rate: number;
  };
}
