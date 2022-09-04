CREATE TABLE public."Users"(
	"Id" uuid NOT NULL,
	"Name" varchar(50) NOT NULL,
	"Email" varchar(50) NOT NULL,
	"Password" text NOT NULL,
	"AvatarId" integer,
	"DateCreated" timestamptz NOT NULL,
	"DateUpdated" timestamptz,
	CONSTRAINT "Pk_UserId" PRIMARY KEY ("Id")

);

ALTER TABLE public."Users" OWNER TO postgres;
