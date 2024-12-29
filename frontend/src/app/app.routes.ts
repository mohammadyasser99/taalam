import { CreateCourseComponent } from './Components/create-course/create-course.component';
import { RouterModule, Routes } from '@angular/router';
import { BlankLayoutComponent } from './Components/blank-layout/blank-layout.component';
import { CartComponent } from './Components/cart/cart.component';
import { HomeComponent } from './Components/home/home.component';
import { AuthLayoutComponent } from './Components/auth-layout/auth-layout.component';

import { NotFoundComponent } from './Components/not-found/not-found.component';
import { CategoryComponent } from './Components/category/category.component';
import { WishlistComponent } from './Components/wishlist/wishlist.component';
import { EditUserProfileComponent } from './Components/edit-user-profile/edit-user-profile.component';
import { UserCoursesComponent } from './Components/user-courses/user-courses.component';
import { CourseLayoutComponent } from './Components/course-layout/course-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { InstructorProfileComponent } from './Components/instructor-profile/instructor-profile.component';
import { NgModule } from '@angular/core';

import { SearchResultComponent } from './Components/search-result/search-result.component';

import { CourseDetailsComponent } from './pages/course-details/course-details.component';
import { CourseContentComponent } from './pages/course-content/course-content.component';

import { ForgetpasswordComponent } from './pages/forgetpassword/forgetpassword.component';
import { ForgetpasswordtokenComponent } from './pages/forgetpasswordtoken/forgetpasswordtoken.component';

import { AuthCallbackComponentComponent } from './Components/auth-callback-component/auth-callback-component.component';
import { AdminComponent } from './pages/admin/admin.component';

import { InstructorComponent } from './Components/instructor/instructor.component';
import { EditCourseComponent } from './Components/edit-course/edit-course.component';

import { PaymentapproveComponent } from './pages/paymentapprove/paymentapprove.component';
import { AdminLayoutComponent } from './pages/admin-layout/admin-layout.component';
import { AdminHomeComponent } from './pages/admin-home/admin-home.component';
import { authGuard, authGuardadmin, authGuardLogin } from './guards/auth.guard';
import { CreateannouncementComponent } from './Components/createannouncement/createannouncement.component';
import { AdminTableComponent } from './Components/admin-table/admin-table.component';

import { CreatecategoryComponent } from './Components/createcategory/createcategory.component';

import { CourseAdminComponent } from './pages/course-admin/course-admin.component';



export const routes: Routes = [
  // { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: '',
    component: BlankLayoutComponent,

    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent, title:"Taalam" },
      { path: 'cart/:id', component: CartComponent, title:"Taalam - Cart", canActivate: [authGuard], },
      { path: 'category/:id', component: CategoryComponent, title:"Taalam - Categories" },
      { path: 'wishlist/:id', component: WishlistComponent, title:"Taalam - Wishlist", canActivate: [authGuard], },
      { path: 'userProfile/:id', component: EditUserProfileComponent, title:"Taalam - UserProfile" , canActivate: [authGuard],},
      { path: 'userCourses', component: UserCoursesComponent , title:"Taalam - My Learning", canActivate: [authGuard], },
      { path: 'instructor/:id', component: InstructorComponent, title: "Taalam - Instructor", canActivate: [authGuard],},
      { path: 'createcourse', component: CreateCourseComponent, title: "Taalam - Create Course", canActivate: [authGuard], },
      { path: 'editcourse/:id', component: EditCourseComponent, title: "Taalam - Edit Course", canActivate: [authGuard], },

      {
        path: 'instructorProfile/:id',
        component: InstructorProfileComponent,
        title: 'Taalam - InstructorProfile',
        canActivate: [authGuard],
      },
      {
        path: 'searchResult/:SearchTerm',
        component: SearchResultComponent,
        title: 'Taalam - SearchResult',
      },
      {
        path: 'course/:id',
        component: CourseDetailsComponent,
        title: 'Taalam - CourseDetails',
      },
      {
        path: 'paymentapprove',
        component: PaymentapproveComponent,
        title: 'Taalam - Search',
        canActivate: [authGuard],
      },
    ],
  },
  {
    path: '',
    component: CourseLayoutComponent,
    children: [
      {
        path: 'coursecontent/:id',
        component: CourseContentComponent,
        title: 'Taalam - Course',
      },
    ],
  },
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      { path: 'home', component: HomeComponent, title: 'Taalam - Home' },
      {
        path: 'login',
        component: LoginComponent,
        title: 'Taalam - Login',
        canActivate: [authGuardLogin],
      },
      {
        path: 'register',
        component: RegisterComponent,
        title: 'Taalam - Register',
        canActivate: [authGuardLogin],
      },
      { path: 'serachResult', component: SearchResultComponent },
      // { path: 'admin', component: AdminComponent },
      {
        path: 'forget-password',
        component: ForgetpasswordComponent,
        title: 'Taalam - ForgetPassword',
      },
      {
        path: 'forget-passwordToken',
        component: ForgetpasswordtokenComponent,
        title: 'Taalam - ForgetPasswordToken',
      },
      { path: 'auth-callback', component: AuthCallbackComponentComponent },
    ],
  },
  {
    path: 'course/content/:courseId',
    component: CourseContentComponent,
    canActivate: [authGuard],
  },
  {
    path: 'course/content/:courseId/:lessonId',
    component: CourseContentComponent,
    canActivate: [authGuard],
  },

  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [authGuardadmin],

    children: [
      { path: '', component: AdminHomeComponent },
      { path: 'courses', component: CourseAdminComponent },
      { path: 'users', component: AdminTableComponent },
      { path: 'announcements', component: CreateannouncementComponent },
      { path: 'categories', component: CreatecategoryComponent },
    ],
  },

  { path: '**', component: NotFoundComponent },
];

//scrollpositionrestoration
@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled', // Enables scroll position restoration
      anchorScrolling: 'enabled', // Optionally enable anchor scrolling for anchor links
      scrollOffset: [0, 64], // Optional: Adjust the scroll offset if you have a sticky header
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
