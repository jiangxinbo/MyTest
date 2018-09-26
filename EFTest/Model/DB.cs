namespace EFTest.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<auth_group> auth_group { get; set; }
        public virtual DbSet<auth_group_permissions> auth_group_permissions { get; set; }
        public virtual DbSet<auth_message> auth_message { get; set; }
        public virtual DbSet<auth_permission> auth_permission { get; set; }
        public virtual DbSet<auth_user> auth_user { get; set; }
        public virtual DbSet<auth_user_groups> auth_user_groups { get; set; }
        public virtual DbSet<auth_user_user_permissions> auth_user_user_permissions { get; set; }
        public virtual DbSet<django_admin_log> django_admin_log { get; set; }
        public virtual DbSet<django_content_type> django_content_type { get; set; }
        public virtual DbSet<django_session> django_session { get; set; }
        public virtual DbSet<django_site> django_site { get; set; }
        public virtual DbSet<ob_activity_list> ob_activity_list { get; set; }
        public virtual DbSet<ob_activity_list_activity_tag> ob_activity_list_activity_tag { get; set; }
        public virtual DbSet<ob_activity_members> ob_activity_members { get; set; }
        public virtual DbSet<ob_activity_tag> ob_activity_tag { get; set; }
        public virtual DbSet<ob_activity_topic> ob_activity_topic { get; set; }
        public virtual DbSet<ob_activity_type> ob_activity_type { get; set; }
        public virtual DbSet<ob_app_info> ob_app_info { get; set; }
        public virtual DbSet<ob_app_version_control> ob_app_version_control { get; set; }
        public virtual DbSet<ob_asset_log> ob_asset_log { get; set; }
        public virtual DbSet<ob_asset_operation_type> ob_asset_operation_type { get; set; }
        public virtual DbSet<ob_asset_safe> ob_asset_safe { get; set; }
        public virtual DbSet<ob_attenuation_pool> ob_attenuation_pool { get; set; }
        public virtual DbSet<ob_auth> ob_auth { get; set; }
        public virtual DbSet<ob_banner> ob_banner { get; set; }
        public virtual DbSet<ob_bourse> ob_bourse { get; set; }
        public virtual DbSet<ob_chain> ob_chain { get; set; }
        public virtual DbSet<ob_charge_editor> ob_charge_editor { get; set; }
        public virtual DbSet<ob_currency> ob_currency { get; set; }
        public virtual DbSet<ob_data_config> ob_data_config { get; set; }
        public virtual DbSet<ob_draft_news> ob_draft_news { get; set; }
        public virtual DbSet<ob_draft_news_tag> ob_draft_news_tag { get; set; }
        public virtual DbSet<ob_editor> ob_editor { get; set; }
        public virtual DbSet<ob_enshrine> ob_enshrine { get; set; }
        public virtual DbSet<ob_error_pwd_log> ob_error_pwd_log { get; set; }
        public virtual DbSet<ob_extract_currency> ob_extract_currency { get; set; }
        public virtual DbSet<ob_feedback> ob_feedback { get; set; }
        public virtual DbSet<ob_friend> ob_friend { get; set; }
        public virtual DbSet<ob_group> ob_group { get; set; }
        public virtual DbSet<ob_group_member> ob_group_member { get; set; }
        public virtual DbSet<integral> integral { get; set; }
        public virtual DbSet<integral_daily_record> integral_daily_record { get; set; }
        public virtual DbSet<integral_log> integral_log { get; set; }
        public virtual DbSet<integral_total_record> integral_total_record { get; set; }
        public virtual DbSet<ob_invitation> ob_invitation { get; set; }
        public virtual DbSet<ob_invitation_record> ob_invitation_record { get; set; }
        public virtual DbSet<ob_login_record> ob_login_record { get; set; }
        public virtual DbSet<ob_media> ob_media { get; set; }
        public virtual DbSet<ob_media_list> ob_media_list { get; set; }
        public virtual DbSet<ob_news> ob_news { get; set; }
        public virtual DbSet<ob_news_flash> ob_news_flash { get; set; }
        public virtual DbSet<ob_news_recommend> ob_news_recommend { get; set; }
        public virtual DbSet<ob_news_tag> ob_news_tag { get; set; }
        public virtual DbSet<ob_share_record> ob_share_record { get; set; }
        public virtual DbSet<ob_tags> ob_tags { get; set; }
        public virtual DbSet<ob_topic> ob_topic { get; set; }
        public virtual DbSet<ob_user> ob_user { get; set; }
        public virtual DbSet<ob_user_record> ob_user_record { get; set; }
        public virtual DbSet<ob_wallet> ob_wallet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<auth_group>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<auth_group>()
                .HasMany(e => e.auth_group_permissions)
                .WithRequired(e => e.auth_group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_group>()
                .HasMany(e => e.auth_user_groups)
                .WithRequired(e => e.auth_group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_message>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<auth_permission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<auth_permission>()
                .Property(e => e.codename)
                .IsUnicode(false);

            modelBuilder.Entity<auth_permission>()
                .HasMany(e => e.auth_group_permissions)
                .WithRequired(e => e.auth_permission)
                .HasForeignKey(e => e.permission_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_permission>()
                .HasMany(e => e.auth_user_user_permissions)
                .WithRequired(e => e.auth_permission)
                .HasForeignKey(e => e.permission_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<auth_user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<auth_user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<auth_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<auth_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<auth_user>()
                .HasMany(e => e.auth_message)
                .WithRequired(e => e.auth_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_user>()
                .HasMany(e => e.auth_user_groups)
                .WithRequired(e => e.auth_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_user>()
                .HasMany(e => e.ob_draft_news)
                .WithRequired(e => e.auth_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_user>()
                .HasMany(e => e.django_admin_log)
                .WithRequired(e => e.auth_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<auth_user>()
                .HasMany(e => e.auth_user_user_permissions)
                .WithRequired(e => e.auth_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<django_admin_log>()
                .Property(e => e.object_id)
                .IsUnicode(false);

            modelBuilder.Entity<django_admin_log>()
                .Property(e => e.object_repr)
                .IsUnicode(false);

            modelBuilder.Entity<django_admin_log>()
                .Property(e => e.change_message)
                .IsUnicode(false);

            modelBuilder.Entity<django_content_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<django_content_type>()
                .Property(e => e.app_label)
                .IsUnicode(false);

            modelBuilder.Entity<django_content_type>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<django_content_type>()
                .HasMany(e => e.auth_permission)
                .WithRequired(e => e.django_content_type)
                .HasForeignKey(e => e.content_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<django_content_type>()
                .HasMany(e => e.django_admin_log)
                .WithOptional(e => e.django_content_type)
                .HasForeignKey(e => e.content_type_id);

            modelBuilder.Entity<django_session>()
                .Property(e => e.session_key)
                .IsUnicode(false);

            modelBuilder.Entity<django_session>()
                .Property(e => e.session_data)
                .IsUnicode(false);

            modelBuilder.Entity<django_site>()
                .Property(e => e.domain)
                .IsUnicode(false);

            modelBuilder.Entity<django_site>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .Property(e => e.activity_poster)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .Property(e => e.amount)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_list>()
                .HasMany(e => e.ob_activity_members)
                .WithRequired(e => e.ob_activity_list)
                .HasForeignKey(e => e.activity_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_activity_list>()
                .HasMany(e => e.ob_activity_list_activity_tag)
                .WithRequired(e => e.ob_activity_list)
                .HasForeignKey(e => e.activitylist_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_activity_members>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_members>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_members>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_members>()
                .Property(e => e.company_name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_members>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_tag>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_tag>()
                .HasMany(e => e.ob_activity_list_activity_tag)
                .WithRequired(e => e.ob_activity_tag)
                .HasForeignKey(e => e.activitytag_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_activity_topic>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_topic>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_topic>()
                .HasMany(e => e.ob_activity_list)
                .WithRequired(e => e.ob_activity_topic)
                .HasForeignKey(e => e.topic_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_activity_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_activity_type>()
                .HasMany(e => e.ob_activity_list)
                .WithRequired(e => e.ob_activity_type)
                .HasForeignKey(e => e.activity_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_app_info>()
                .Property(e => e.app_name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_info>()
                .Property(e => e.app_key)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_info>()
                .Property(e => e.app_secret)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_info>()
                .Property(e => e.white_ip)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_info>()
                .Property(e => e.white_org)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_version_control>()
                .Property(e => e.app_type)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_version_control>()
                .Property(e => e.app_version)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_version_control>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_version_control>()
                .Property(e => e.minimum_support)
                .IsUnicode(false);

            modelBuilder.Entity<ob_app_version_control>()
                .Property(e => e.redirect_url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_asset_log>()
                .Property(e => e.onley_num)
                .IsUnicode(false);

            modelBuilder.Entity<ob_asset_log>()
                .Property(e => e.cause)
                .IsUnicode(false);

            modelBuilder.Entity<ob_asset_operation_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_asset_operation_type>()
                .HasMany(e => e.ob_asset_log)
                .WithOptional(e => e.ob_asset_operation_type)
                .HasForeignKey(e => e.operation_type_id);

            modelBuilder.Entity<ob_asset_safe>()
                .Property(e => e.payment_num)
                .IsUnicode(false);

            modelBuilder.Entity<ob_asset_safe>()
                .Property(e => e.phone_num)
                .IsUnicode(false);

            modelBuilder.Entity<ob_auth>()
                .Property(e => e.identifier)
                .IsUnicode(false);

            modelBuilder.Entity<ob_auth>()
                .Property(e => e.credential)
                .IsUnicode(false);

            modelBuilder.Entity<ob_auth>()
                .Property(e => e.union_id)
                .IsUnicode(false);

            modelBuilder.Entity<ob_banner>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_banner>()
                .Property(e => e.pic)
                .IsUnicode(false);

            modelBuilder.Entity<ob_banner>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_bourse>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_bourse>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ob_chain>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_chain>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ob_charge_editor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_charge_editor>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<ob_charge_editor>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<ob_charge_editor>()
                .HasMany(e => e.ob_news)
                .WithRequired(e => e.ob_charge_editor)
                .HasForeignKey(e => e.charge_editor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_charge_editor>()
                .HasMany(e => e.ob_draft_news)
                .WithOptional(e => e.ob_charge_editor)
                .HasForeignKey(e => e.charge_editor_id);

            modelBuilder.Entity<ob_currency>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_currency>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<ob_currency>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<ob_currency>()
                .HasMany(e => e.ob_asset_log)
                .WithOptional(e => e.ob_currency)
                .HasForeignKey(e => e.currency_id);

            modelBuilder.Entity<ob_currency>()
                .HasMany(e => e.ob_wallet)
                .WithOptional(e => e.ob_currency)
                .HasForeignKey(e => e.currency_id);

            modelBuilder.Entity<ob_currency>()
                .HasMany(e => e.ob_extract_currency)
                .WithOptional(e => e.ob_currency)
                .HasForeignKey(e => e.currency_id);

            modelBuilder.Entity<ob_data_config>()
                .Property(e => e.task_name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.subhead)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.abstractx)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.new_editor)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.figure)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.reprint_title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.reprint_url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .Property(e => e.media_str)
                .IsUnicode(false);

            modelBuilder.Entity<ob_draft_news>()
                .HasMany(e => e.ob_draft_news_tag)
                .WithRequired(e => e.ob_draft_news)
                .HasForeignKey(e => e.newsdraft_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_editor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_editor>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<ob_editor>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<ob_editor>()
                .HasMany(e => e.ob_draft_news)
                .WithOptional(e => e.ob_editor)
                .HasForeignKey(e => e.editor_id);

            modelBuilder.Entity<ob_editor>()
                .HasMany(e => e.ob_news)
                .WithOptional(e => e.ob_editor)
                .HasForeignKey(e => e.editor_id);

            modelBuilder.Entity<ob_error_pwd_log>()
                .Property(e => e.payment_num)
                .IsUnicode(false);

            modelBuilder.Entity<ob_extract_currency>()
                .Property(e => e.only_num)
                .IsUnicode(false);

            modelBuilder.Entity<ob_extract_currency>()
                .Property(e => e.txid)
                .IsUnicode(false);

            modelBuilder.Entity<ob_extract_currency>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<ob_feedback>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<ob_feedback>()
                .Property(e => e.ci_type)
                .IsUnicode(false);

            modelBuilder.Entity<ob_feedback>()
                .Property(e => e.ci_number)
                .IsUnicode(false);

            modelBuilder.Entity<ob_friend>()
                .Property(e => e.name_note)
                .IsUnicode(false);

            modelBuilder.Entity<ob_group>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_group>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<ob_group>()
                .HasMany(e => e.ob_group_member)
                .WithRequired(e => e.ob_group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_group_member>()
                .Property(e => e.name_note)
                .IsUnicode(false);

            modelBuilder.Entity<integral_log>()
                .Property(e => e.cause)
                .IsUnicode(false);

            modelBuilder.Entity<integral_log>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<ob_invitation>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<ob_invitation>()
                .Property(e => e.share_img)
                .IsUnicode(false);

            modelBuilder.Entity<ob_invitation_record>()
                .Property(e => e.inviter)
                .IsUnicode(false);

            modelBuilder.Entity<ob_invitation_record>()
                .Property(e => e.invitee)
                .IsUnicode(false);

            modelBuilder.Entity<ob_invitation_record>()
                .Property(e => e.sta_date)
                .IsUnicode(false);

            modelBuilder.Entity<ob_login_record>()
                .Property(e => e.sta_date)
                .IsUnicode(false);

            modelBuilder.Entity<ob_media>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_media>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ob_media_list>()
                .Property(e => e.media_url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_media_list>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.subhead)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.abstractx)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.new_editor)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.figure)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.reprint_title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.reprint_url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .Property(e => e.media_str)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news>()
                .HasMany(e => e.ob_attenuation_pool)
                .WithRequired(e => e.ob_news)
                .HasForeignKey(e => e.news_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_news>()
                .HasMany(e => e.ob_enshrine)
                .WithRequired(e => e.ob_news)
                .HasForeignKey(e => e.new_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_news>()
                .HasMany(e => e.ob_media_list)
                .WithRequired(e => e.ob_news)
                .HasForeignKey(e => e.news_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_news>()
                .HasMany(e => e.ob_user_record)
                .WithRequired(e => e.ob_news)
                .HasForeignKey(e => e.new_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_news>()
                .HasMany(e => e.ob_news_tag)
                .WithRequired(e => e.ob_news)
                .HasForeignKey(e => e.news_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_news_flash>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news_flash>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news_flash>()
                .Property(e => e.reprint_title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news_flash>()
                .Property(e => e.reprint_url)
                .IsUnicode(false);

            modelBuilder.Entity<ob_news_recommend>()
                .Property(e => e.new_title)
                .IsUnicode(false);

            modelBuilder.Entity<ob_share_record>()
                .Property(e => e.sta_date)
                .IsUnicode(false);

            modelBuilder.Entity<ob_share_record>()
                .Property(e => e.news_id)
                .IsUnicode(false);

            modelBuilder.Entity<ob_tags>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_tags>()
                .HasMany(e => e.ob_draft_news_tag)
                .WithRequired(e => e.ob_tags)
                .HasForeignKey(e => e.tag_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_tags>()
                .HasMany(e => e.ob_news_tag)
                .WithRequired(e => e.ob_tags)
                .HasForeignKey(e => e.tag_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_topic>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ob_topic>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ob_topic>()
                .HasMany(e => e.ob_draft_news)
                .WithOptional(e => e.ob_topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<ob_topic>()
                .HasMany(e => e.ob_news)
                .WithRequired(e => e.ob_topic)
                .HasForeignKey(e => e.topic_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.province)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .Property(e => e.refresh_token)
                .IsUnicode(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_asset_log)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_asset_safe)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_charge_editor)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_editor)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_enshrine)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_error_pwd_log)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_extract_currency)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_friend)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.friend_user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_friend1)
                .WithOptional(e => e.ob_user1)
                .HasForeignKey(e => e.main_user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_group)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.main_user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_group_member)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.member_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.integral)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.integral_log)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_invitation)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_login_record)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_share_record)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_wallet)
                .WithOptional(e => e.ob_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<ob_user>()
                .HasMany(e => e.ob_user_record)
                .WithRequired(e => e.ob_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
