import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ContactMaster } from '../contact';
import { Contactservice } from '../contactservice.service';

@Component({
  selector: 'create-contact',
  templateUrl: './createcontact.component.html',
  styleUrls: ['./createcontact.component.scss']
})
export class CreatecontactComponent implements OnInit {

  createContactForm: FormGroup;
  title:string="New Contact";
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public toastr: ToastrManager,
    private contactService: Contactservice
  ) {

    this.createContactForm = formBuilder.group({
      ContactId: [0],
      FirstName: ["", Validators.required],
      LastName: ["", Validators.required],
      PhoneNumber: ["",Validators.pattern('[6-9]\\d{9}')],
      Email: ["", Validators.email],
      IsActive: [true],
    });
  }

  ngOnInit() {

    this.activatedRoute.queryParams.subscribe(params => {
      const contactId = params['contactId'];
      if (contactId != null) {
        this.title = "Update Contact"
        this.GetContactDetails(contactId);
      }
      else 
      {
        this.title = "New Contact";
      }
    });

  }
  GetContactDetails(contactId: number) {
    this.contactService.getContact(contactId).subscribe(res => {
      this.createContactForm.patchValue({
        ContactId: res.ContactId,
        FirstName: res.FirstName,
        LastName: res.LastName,
        PhoneNumber: res.PhoneNumber,
        Email: res.Email,
        IsActive: res.IsActive,
      });
    });
  }

  saveContact() {
   
    if (this.createContactForm.valid) {
      let contactMaster: ContactMaster = this.createContactForm.value;
      if (contactMaster.ContactId > 0) {
        this.contactService.UpdateContact(contactMaster).subscribe(res => {
          this.toastr.successToastr("Contact updated successfully", "Success!");
          this.router.navigate(["contacts"]);
        }, (error) => {
          this.toastr.successToastr(error.error, "Error!");
        });
      }
      else {
        this.contactService.addContact(contactMaster).subscribe(res => {
          this.toastr.successToastr("Contact added successfully", "Success!");
          this.router.navigate(["contacts"]);
        }, (error) => {
          this.toastr.successToastr(error.error, "Error!");
        });
      }
    } else {
      this.toastr.warningToastr("This is not a valid form.", "Alert!");
    }
  }

}
