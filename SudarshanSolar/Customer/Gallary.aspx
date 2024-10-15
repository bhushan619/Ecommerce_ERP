<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="Gallary.aspx.cs" Inherits="SudarshanSolar.Customer.Gallary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    			<section class="page_breadcrumbs ds ms parallax  section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Gallery</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
							
								<li class="active">Gallery</li>
							</ol>
						</div>
					</div>
				</div>
			</section>
       <section class="ls ms  columns_padding_25 section_padding_top_50 ">
          			<div class="container ">
                		    <div class="row">

							<div class="filters isotope_filters text-center">
                <a href="gallery.aspx#" data-filter="*" class="active">All</a>
          <asp:ListView ID="ListView1" runat="server" DataSourceID="sqlGalleryAlbum" DataKeyNames="album"> 
              <EmptyDataTemplate>
                  <span><div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
					                                                </div></span>
              </EmptyDataTemplate> 
              <ItemTemplate> 
                  			
  <a href="gallery.aspx#" data-filter='.<%# Eval("album").ToString().Replace(" ",string.Empty) %>'><%# Eval("album") %></a>
              </ItemTemplate>
              <LayoutTemplate>
                    <span runat="server" id="itemPlaceholder" /> 
              </LayoutTemplate> 
          </asp:ListView> 

                                </div>
                                </div>
                          <div class="row section_padding_bottom_15">
                          						<div class="isotope_container isotope row masonry-layout" data-filters=".isotope_filters">
  <asp:ListView ID="ListView2" runat="server" DataSourceID="sqlGalleryImages" DataKeyNames="intGalleryId">
             
             
            <EmptyDataTemplate>
                <span><div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
					                                                </div></span>
            </EmptyDataTemplate>
             
            <ItemTemplate>
								<div class='<%# "isotope-item col-lg-3 col-md-4 col-sm-6 " + Eval("album").ToString().Replace(" ",string.Empty) %>'>
									<div class="vertical-item gallery-title-item content-absolute">
										<div class="item-media">
                                              <img src='<%# "../Media/galleryimages/" + Eval("varImagePath") %>' alt='<%# Eval("VarCaption") %>'  />
                 
											
											<div class="media-links">
												<div class="links-wrap">
												
												   <a class="p-view prettyPhoto " href='<%# "../Media/galleryimages/" + Eval("varImagePath") %>' data-gal="prettyPhoto[gal]">
												</div>
											</div>
										</div>
									</div>
                                    </div>
                  </ItemTemplate>
            <LayoutTemplate>
             <span runat="server" id="itemPlaceholder" /> 
            </LayoutTemplate>
             
        </asp:ListView>
           <asp:SqlDataSource ID="sqlGalleryAlbum" runat="server" 
            ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                        SelectCommand="SELECT distinct varAlbum as album FROM tblhhigallery" 
          >        
        </asp:SqlDataSource> 
                                                        <asp:SqlDataSource ID="sqlGalleryImages" runat="server" 
            ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                        SelectCommand="SELECT intGalleryId, (SELECT varAlbum FROM tblhhigallery WHERE intID=intEventId) as album, VarCaption, varImagePath FROM tblhhiphotoupload" 
          >        
        </asp:SqlDataSource> 
                                                      </div>
                       </div>  

          			</div>
           </section>
</asp:Content>
