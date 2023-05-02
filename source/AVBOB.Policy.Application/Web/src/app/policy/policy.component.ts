import { Component, Inject } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppService } from '../app.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent {

  public FormGroup = new FormGroup({
    Id: new FormControl(0),
    PolicyNumber: new FormControl(''),
    PolicyTypeId: new FormControl(''),
    PolicyHolderId: new FormControl(''),
    CommencementDate: new FormControl(''),
    Installment: new FormControl(''),
    ApplicationFormDocumentId: new FormControl(0),
    IsActive: new FormControl(true),
    DateCreated: new FormControl(new Date()),
  });

  public PolicyTypes: any[] = [];

  public Note: any = {
    Content: "",
    NoteType: "",
    Display: false
  };

  public loading: boolean = false;
  public loadingDelete: boolean = false;

  public ApplicationForm: any = null;

  public URL: string = environment.API.DataStore + "Documents/";

  public uploadLoading: boolean = false;

  public formTouched: boolean = false;

  constructor(
    public _appService: AppService,
    public dialogRef: MatDialogRef<PolicyComponent>,
    @Inject(MAT_DIALOG_DATA) public _data: any,
  ) {
    this.GetLookups();
    this.FormGroup.patchValue({
      PolicyHolderId: _data.parent
    });
    if (_data.data.Id != undefined) {
      this.ApplicationForm = _data.data.ApplicationFormDocument;
      this.FormGroup.patchValue({
        Id: _data.data.Id,
        PolicyNumber: _data.data.PolicyNumber,
        PolicyTypeId: _data.data.PolicyTypeId,
        PolicyHolderId: _data.data.PolicyHolderId,
        CommencementDate: _data.data.CommencementDate,
        Installment: _data.data.Installment,
        ApplicationFormDocumentId: _data.data.ApplicationFormDocumentId,
        IsActive: _data.data.IsActive,
        DateCreated: _data.data.DateCreated,
      });
    }
  }

  public Submit(): any {
    this.formTouched = true;
    if (this.FormGroup.valid && !this.loading && this.ApplicationForm != null && !this.loadingDelete) {
      this.loading = true;
      let form: any = this.FormGroup.getRawValue();
      form.ApplicationFormDocument = this.ApplicationForm;
      if (form.Id == 0) {
        this._appService.PostFormData(
          "Policy",
          `Create`,
          form
        ).subscribe((x: any) => {
          setTimeout(() => {
            this.FormGroup.patchValue({
              Id: x.Data.Id,
              DateCreated: x.Data.DateCreated,
            });
            this.loading = false;
            this.Note = {
              Content: "Policy created successfully.",
              NoteType: "success",
              Display: true
            };
            setTimeout(() => {
              this.close();
            }, 3000);
          }, 1000);
        });
      }
      else {
        this._appService.PutFormData(
          "Policy",
          `Update`,
          form.Id,
          form
        ).subscribe((x: any) => {
          setTimeout(() => {
            this.FormGroup.patchValue({
              Id: x.Data.Id,
              DateCreated: x.Data.DateCreated,
            });
            this.loading = false;
            this.Note = {
              Content: "Policy updated successfully.",
              NoteType: "success",
              Display: true
            };
            setTimeout(() => {
              this.close();
            }, 3000);
          }, 1000);
        });
      }
    }
  }

  public Delete() {
    this.loadingDelete = true;
    this._appService.DeleteMethod(
      "Policy",
      `Delete`,
      this.FormGroup.getRawValue().Id
    ).subscribe((x: any) => {
      setTimeout(() => {
        this.Note = {
          Content: "Policy deteled successfully.",
          NoteType: "danger",
          Display: true
        };
        setTimeout(() => {
          this.close();
        }, 3000);
      }, 1000);
    });
  }

  public close() {
    this.dialogRef.close();
  }

  public FileInputChange(event: any) {
    if (event.files.length > 0 && !this.uploadLoading) {
      this.uploadLoading = true;
      let uploadFile: File = event.files[0];
      let formData = new FormData();
      formData.append("file", uploadFile)
      this._appService.PostFormData(
        "Document",
        `UploadDocument`,
        formData
      ).subscribe((x: any) => {
        setTimeout(() => {
          this.ApplicationForm = x;
          this.ApplicationForm.DocumentTypeId = 1;
          this.uploadLoading = false;
        }, 1000);
      });
    }
  }

  public GetLookups() {
    this._appService.GetMethod("Lookup", 'GetPolicyTypes').subscribe((x: any) => {
      this.PolicyTypes = x.Data;
    });
  }
}