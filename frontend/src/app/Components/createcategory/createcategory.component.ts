import { response } from 'express';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-createcategory',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './createcategory.component.html',
  styleUrls: ['./createcategory.component.css'],
})
export class CreatecategoryComponent implements OnInit {
  @ViewChild('closecreate') closecreate!: ElementRef<HTMLButtonElement>;

  categories: any[] = [];
  newCategory: { name: string } = { name: '' };
  selectedFile: File | null = null;
  updateCategory: any = {};

  constructor(private _CategoryService: CategoryService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this._CategoryService.getCategories().subscribe((data: any[]) => {
      this.categories = data;
    });
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  onSubmitCreateCategory(): void {
    const formData = new FormData();
    formData.append('name', this.newCategory.name);
    if (this.selectedFile) {
      formData.append('image', this.selectedFile);
    }

    this._CategoryService.createCategory(formData).subscribe(() => {
      this.loadCategories();
      this.newCategory.name = '';
      this.selectedFile = null;
      this.closecreate.nativeElement.click();
    });
  }

  // getCategoryById(id: number) {
  //   this._CategoryService.getCategoryById(id).subscribe({
  //     next: (response) => {
  //       this.updateCategory = response;
  //       console.log(response);
  //     },
  //   });
  // }

  // openUpdateCategoryModal(category: any): void {
  //   this.updateCategory = { ...category }; // Copy category data to update
  //   // (document.getElementById('updateCategoryModal') as any).click(); // Open the modal
  // }

  // onSubmitUpdateCategory(): void {
  //   const formData = new FormData();
  //   formData.append('id', this.updateCategory.id);
  //   formData.append('name', this.updateCategory.name);
  //   if (this.updateCategory.file) {
  //     formData.append('image', this.updateCategory.file);
  //   }

  //   console.log(formData);

  //   this._CategoryService
  //     .updateCategory(this.updateCategory.id, formData)
  //     .subscribe(() => {
  //       this.loadCategories(); // Reload categories after update
  //       this.updateCategory = {}; // Reset the update form
  //       (document.getElementById('updateCategoryModal') as any).click(); // Close the modal
  //     });
  // }

  // onDeleteCategory(id: number): void {
  //   this._CategoryService.deleteCategory(id).subscribe(() => {
  //     this.loadCategories(); // Reload categories after deletion
  //   });
  // }
}
