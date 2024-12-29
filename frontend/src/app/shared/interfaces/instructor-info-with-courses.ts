export interface InstructorInfoWithCourses {
  fName: string;
  lName: string;
  description: string;
  github: string;
  facebook: string;
  linkedin: string;
  youtube: string;
  twitter: string;
  profilePicture: string;
  profilePictureFile?: File;
  totalStudents: number;
  totalReviews: number;
  ownedCourses: OwnedCourses[];
}
export interface IUserProfile{
  id:number|string;
  fName: string;
  lName: string;
  description: string;
  github: string;
  facebook: string;
  linkedin: string;
  youtube: string;
  twitter: string;
  profilePicture: string;
  profilePictureFile?: File;
}


export interface OwnedCourses {
  id: number;
  title: string;
  description: string;
  coverPicture: string;
  price: number;
  rate: number;
  category:string;
}
