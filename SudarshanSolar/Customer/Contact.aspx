<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SudarshanSolar.Customer.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Contact</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Contact.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">Contact</li>
							</ol>
						</div>
					</div>
				</div>
			</section>
   

    <section class="ls ms columns_padding_25 section_padding_top_50 section_padding_bottom_75">
				<div class="container">
					<div class="row">

						<div class="col-md-8 to_animate" data-animation="scaleAppear">

							<h3 class="module-header">Contact Form</h3>

							<div class="contact-form row columns_padding_5" >


								<div class="col-sm-6">
									<div class="contact-form-name">
										<label for="name">Full Name
											<span class="required">*</span>
										</label>
                                         <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Full Name"  aria-required="true" size="30" runat="server" required="required"  ></asp:TextBox> 
               
							
									</div>
								</div>
								<div class="col-sm-6">
										<div class="contact-form-email">
										<label for="email">Email address
											<span class="required">*</span>
										</label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" aria-required="true" size="30" runat="server" required="required" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" placeholder="E-Mail Address"></asp:TextBox> 
             
									
									</div>
								</div>
								<div class="col-sm-6">
									<div class="contact-form-phone">
										<label for="phone">Mobile
											<span class="required">*</span>
										</label>
										 <asp:TextBox ID="txtPhone" CssClass="form-control" placeholder="Mobile Number"  aria-required="true" size="30" runat="server" required="required"  ></asp:TextBox> 
               	</div>
								</div>
								<div class="col-sm-6"><div class="contact-form-subject">
										<label for="subject">Subject
											<span class="required">*</span>
										</label>
                                           <asp:TextBox ID="txtsubject" size="30" CssClass="form-control" runat="server" required="required" placeholder="Subject"></asp:TextBox> 
             	</div>
								
								</div>
								<div class="col-sm-12">

									<div class="contact-form-message">
										<label for="message">Message</label>
                                          <asp:TextBox ID="txtMessage" CssClass="form-control" rows="6" cols="45" runat="server" TextMode="MultiLine" required="required" placeholder="Message"></asp:TextBox> 
              

									</div>
								</div>

								<div class="col-sm-12">

									<div class="contact-form-submit topmargin_30">
                                           <asp:Button ID="btnSubmit" runat="server" Text="Send Message" CssClass="theme_button wide_button color1" OnClick="btnSubmit_Click" /> 

										<button type="reset" id="contact_form_reset" name="contact_reset" class="theme_button wide_button">Clear Form</button>
									</div>
								</div>
                                	<div class="col-sm-12">
                                   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
</div>

							</div>
						</div>

						<div class="col-md-4 to_animate" data-animation="scaleAppear">

							<div class="with_background page-meta">
								<div class="media">
									<div class="media-left">
										<i class="rt-icon2-shop highlight fontsize_18"></i>
									</div>
									<div class="media-body">
										<h5 class="media-heading grey">Postal Address:</h5>
									5, Tarak Colony, Opp. Ramakrishna
Mission Ashrama, Beed bypass,
Aurangabad - 431 005. (MH), India.
									</div>
								</div>

								<div class="media">
									<div class="media-left">
										<i class="rt-icon2-phone5 highlight fontsize_18"></i>
									</div>
									<div class="media-body">
										<h5 class="media-heading grey">Phone:</h5>
										+91-240-2376609/10
									</div>
								</div>

								<div class="media">
									<div class="media-left">
										<i class="rt-icon2-stack4 highlight fontsize_18"></i>
									</div>
									<div class="media-body">
										<h5 class="media-heading grey">Fax:</h5>
											+91-240-2376609/10
									</div>
								</div>

								<div class="media">
									<div class="media-left">
										<i class="rt-icon2-mail highlight fontsize_18"></i>
									</div>
									<div class="media-body">
										<h5 class="media-heading grey">Email:</h5>
										works@sudarshansaur.com
									</div>
								</div>

							</div>

						</div>

					</div>
				</div>
			</section>
     <section class="ls"  >
				<!-- marker description and marker icon goes here -->
				
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3752.6999977551764!2d75.31005751448212!3d19.85264278664706!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bdb98f406a92b4b%3A0x813522ee5986430b!2sRamakrishna+Mission+Ashrama!5e0!3m2!1sen!2sin!4v1485515497578" width="1400px" height="390px" frameborder="0" style="border:0" allowfullscreen></iframe>
		
			</section>
</asp:Content>
