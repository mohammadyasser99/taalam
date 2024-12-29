import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-share-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './share-modal.component.html',
  styleUrl: './share-modal.component.css',
})
export class ShareModalComponent {
  @Input() shareLink: string = ''; // The link to share
  @Input() courseId!: number; // Accept only courseId

  @Input() shareDetails: any; // Customize as needed
  activeModal = inject(NgbActiveModal);

  closeModal() {
    this.activeModal.dismiss();
  }
  // Function to copy the link to the clipboard
  copyToClipboard() {
    navigator.clipboard.writeText(this.shareLink).then(() => {
      alert('Link copied to clipboard!');
    });
  }


  // Function to share via Email
  shareViaEmail() {
    const emailUrl = `mailto:?subject=Check out this course&body=${encodeURIComponent(
      this.shareLink
    )}`;
    window.open(emailUrl, '_blank');
  }

  // Function to share via SMS
  shareViaSMS() {
    const smsUrl = `sms:?body=${encodeURIComponent(this.shareLink)}`;
    window.open(smsUrl, '_blank');
  }


  // Function to share on WhatsApp
  shareOnWhatsApp() {
    const whatsappUrl = `https://api.whatsapp.com/send?text=${encodeURIComponent(
      this.shareLink
    )}`;
    window.open(whatsappUrl, '_blank');
  }
}
