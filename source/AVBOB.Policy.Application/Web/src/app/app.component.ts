import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { AppService } from './app.service';
import { FormControl, FormGroup } from '@angular/forms';
import { PolicyComponent } from './policy/policy.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  dataSource = new MatTableDataSource<any>([]);
  displayedColumns: string[] = ['PolicyNumber', 'PolicyType', 'Installment', 'action'];
  displayedColumnsDescriptions: string[] = ['Policy Number', 'Policy Type', 'Installment', ''];


  public PageEvent: PageEvent = { pageIndex: 0, pageSize: 10, length: 0 };

  public Genders: any[] = [];

  public FormGroup = new FormGroup({
    Id: new FormControl(0),
    IDNumber: new FormControl(''),
    Initials: new FormControl(''),
    Surname: new FormControl(''),
    DateOfBirth: new FormControl(''),
    GenderId: new FormControl(''),
    IsActive: new FormControl(true),
    DateCreated: new FormControl(new Date()),
  });


  public Note: any = {
    Content: "",
    NoteType: "",
    Display: false
  };

  public loading: boolean = false;

  public AutoCompleteResults: any[] = [];
  public Policies: any[] = [];

  constructor(
    public dialog: MatDialog,
    public route: ActivatedRoute,
    public _appService: AppService
  ) {

  }

  ngOnInit(): void {
    this.GetLookups();
  }

  public Submit() {
    if (this.FormGroup.valid && !this.loading) {
      this.loading = true;
      let form: any = this.FormGroup.getRawValue();
      if (form.Id == 0) {
        this._appService.PostFormData(
          "PolicyHolder",
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
              Content: "Policy holder created successfully.",
              NoteType: "success",
              Display: true
            };
          }, 1000);
        });
      }
      else {
        this._appService.PutFormData(
          "PolicyHolder",
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
              Content: "Policy holder updated successfully.",
              NoteType: "success",
              Display: true
            };
          }, 1000);
        });
      }
    }
  }

  public IDNumberKeyUp() {
    let IDNumber = this.FormGroup.getRawValue().IDNumber;
    if (IDNumber.length > 0) {
      this._appService.GetMethod(
        "PolicyHolder",
        `Search/${IDNumber}`
      ).subscribe((x: any) => {
        if(x.Data != undefined){
          this.AutoCompleteResults = x.Data;
        }
      });
    } else {
      this.AutoCompleteResults = [];
    }
  }

  public SearchClick(item: any) {
    this.FormGroup.patchValue({
      Id: item.Id,
      IDNumber: item.Idnumber,
      Initials: item.Initials,
      Surname: item.Surname,
      DateOfBirth: new Date(item.DateOfBirth),
      GenderId: item.GenderId,
      IsActive: item.IsActive,
      DateCreated: item.DateCreated
    });
    this.AutoCompleteResults = [];
    this.SeachPolicies();
  }

  public SeachPolicies() {
    this._appService.PostFormData(
      "Policy",
      `Search`,
      {
        Id: this.FormGroup.getRawValue().Id,
        PageIndex: this.PageEvent.pageIndex,
        PageSize: this.PageEvent.pageSize
      }
    ).subscribe((x: any) => {
      this.Policies = x.Data.Results;
      let data: any[] = [];
      x.Data.Results.forEach((element: any) => {
        data.push({
          Id: element.Id,
          PolicyNumber: element.PolicyNumber,
          PolicyType: element.PolicyType.Description,
          Installment: element.Installment
        });
      });
      this.PageEvent.length = x.Data.Count
      this.dataSource = new MatTableDataSource<any>(data);
    });
  }

  public Cancel() {
    this.FormGroup.patchValue({
      Id: 0,
      IDNumber: "",
      Initials: "",
      Surname: "",
      DateOfBirth: "",
      GenderId: ""
    });
    this.AutoCompleteResults = [];
    this.dataSource = new MatTableDataSource<any>([]);
    this.PageEvent = { pageIndex: 0, pageSize: 10, length: 0 };
  }

  public GetLookups() {
    this._appService.GetMethod("Lookup", 'GetGenders').subscribe((x: any) => {
      this.Genders = x.Data;
    });
  }

  public page(page: PageEvent): void {
    this.PageEvent = page;
    this.SeachPolicies();
  }

  public AddPolicy(item: any) {
    if (item.Id != undefined) {
      item = this.Policies.find(x => x.Id == item.Id);
    }
    const dialogRef = this.dialog.open(PolicyComponent, {
      width: '80%',
      data: {
        data: item,
        parent: this.FormGroup.getRawValue().Id
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.PageEvent = { pageIndex: 0, pageSize: 10, length: 0 };
      this.SeachPolicies();
    });
  }
}
