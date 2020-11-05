import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogData } from 'src/app/Models/DialogData';

@Component({
  selector: 'app-alert-dialog',
  templateUrl: './alert-dialog.component.html',
  styleUrls: ['./alert-dialog.component.css']
})
export class AlertDialogComponent implements OnInit {

 constructor(
   public dialogRef: MatDialogRef<AlertDialogComponent>,
   @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit() {
  }

 onClickNO(): void {
  this.dialogRef.close();
 }
}
