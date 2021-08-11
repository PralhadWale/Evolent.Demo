import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ContactMaster } from '../contact';
import { Contactservice } from '../contactservice.service';

@Component({
  selector: 'list-contacts',
  templateUrl: './listcontacts.component.html',
  styleUrls: ['./listcontacts.component.scss']
})
export class ListcontactsComponent implements OnInit {

  contactList:Array<ContactMaster>=[];

  constructor(private contactService:Contactservice, private router:Router, public toastr: ToastrManager) { }

  ngOnInit(): void {
    this.GetAll();
  }

  private GetAll() {
    this.contactService.getALLContact().subscribe(result => {
      this.contactList = result;
    }, (error) => {
      this.toastr.errorToastr(error.error, "Error!");
    });
  }

  ViewContact(contactId : number)
  {
    this.router.navigate(["create"], { queryParams: { contactId: contactId } });
  }

  DeleteContact(contactId : number)
  {
    this.contactService.deleteContact(contactId).subscribe(result => {
     if(result)
     {
       this.toastr.successToastr("Contact Deleted Successfully","Success!!");
       this.GetAll();
     }
    }, (error) => {
      this.toastr.errorToastr(error.error, "Error!");
    });
  }

}
